using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace SudokuRecursivo;

/// <summary>
/// Interfaz: dibuja el tablero, permite editarlo, resuelve con animación
/// y ejecuta los experimentos de profundidad con su gráfica.
/// </summary>
public partial class Form1 : Form
{
    // Tableros de ejemplo (81 caracteres, 0 = vacío)
    private const string TableroClasico = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
    private const string TableroInkala = "800000000003600000070090200050007000000045700000100030001000068008500010090000400";
    private const float Margen = 2f;
    private static readonly int[] PasosPorTick = { 1, 2, 5, 10, 25, 50, 100, 250, 500, 1000 };

    private readonly Random _random = new();
    private readonly Font _fuenteFija = new("Segoe UI", 18F, FontStyle.Bold);
    private readonly Font _fuenteNormal = new("Segoe UI", 18F);
    private readonly Pen _lapizGrueso = new(Color.FromArgb(31, 58, 96), 3F);
    private readonly Pen _lapizDelgado = new(Color.FromArgb(190, 198, 210), 1F);
    private readonly SolidBrush _pincel = new(Color.White);

    private int[,] _inicial = new int[Sudoku.N, Sudoku.N];   // números dados (fijos)
    private int[,] _tablero = new int[Sudoku.N, Sudoku.N];   // lo que se dibuja
    private int[,]? _solucion;
    private (int Fila, int Col)? _seleccion;
    private Paso? _ultimo;
    private List<Paso> _pasos = new();
    private int _indicePaso;
    private bool _ocupado;
    private List<ResultadoExperimento> _resultados = new();

    public Form1()
    {
        InitializeComponent();
        picGrafica.Resize += (_, _) => picGrafica.Invalidate();
    }

    // ═══════════════════════ CARGA Y EDICIÓN DEL TABLERO ═══════════════════════

    private void Form1_Load(object? sender, EventArgs e)
    {
        cmbPuzzle.Items.AddRange(new object[]
        {
            "Clásico (Wikipedia) – 51 vacías",
            "Difícil (Inkala, 2012) – 60 vacías",
            "Aleatorio",
            "Vacío (escribir el propio)"
        });
        cmbPuzzle.SelectedIndex = 0;
        CargarTablero();
    }

    private void CmbPuzzle_SelectedIndexChanged(object? sender, EventArgs e) =>
        nudVacias.Enabled = cmbPuzzle.SelectedIndex == 2;

    private void BtnCargar_Click(object? sender, EventArgs e) => CargarTablero();

    private void CargarTablero()
    {
        _inicial = cmbPuzzle.SelectedIndex switch
        {
            0 => Sudoku.Parsear(TableroClasico),
            1 => Sudoku.Parsear(TableroInkala),
            2 => Sudoku.GenerarPuzzle((int)nudVacias.Value, _random),
            _ => new int[Sudoku.N, Sudoku.N]
        };
        _tablero = Sudoku.Clonar(_inicial);
        _solucion = null;
        _ultimo = null;
        _seleccion = null;
        LimpiarMetricas();
        picTablero.Invalidate();
        lblEstado.Text = $"Tablero cargado: {Sudoku.ContarVacias(_inicial)} celdas vacías";
    }

    private void PicTablero_MouseClick(object? sender, MouseEventArgs e)
    {
        float celda = TamanoCelda();
        int col = (int)((e.X - Margen) / celda);
        int fila = (int)((e.Y - Margen) / celda);

        if (fila is >= 0 and < Sudoku.N && col is >= 0 and < Sudoku.N)
        {
            _seleccion = (fila, col);
            ActiveControl = null;          // el teclado ya no escribe en otros controles
            picTablero.Invalidate();
        }
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (_ocupado || _seleccion is null || tabResultados.SelectedTab != tabSudoku)
            return;

        int valor = e.KeyCode switch
        {
            >= Keys.D1 and <= Keys.D9 => e.KeyCode - Keys.D0,
            >= Keys.NumPad1 and <= Keys.NumPad9 => e.KeyCode - Keys.NumPad0,
            Keys.Delete or Keys.Back or Keys.D0 or Keys.NumPad0 => 0,
            _ => -1
        };
        if (valor < 0)
            return;

        var (fila, col) = _seleccion.Value;
        int valorAnterior = _inicial[fila, col];
        _inicial[fila, col] = valor;

        try
        {
            Sudoku.ValidarTablero(_inicial);
        }
        catch (ArgumentException)
        {
            _inicial[fila, col] = valorAnterior;
            MessageBox.Show("Tablero no válido", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Handled = true;
            return;
        }

        _tablero = Sudoku.Clonar(_inicial);
        _solucion = null;
        _ultimo = null;
        e.Handled = true;
        picTablero.Invalidate();
        lblEstado.Text = $"Tablero editado: {Sudoku.ContarVacias(_inicial)} celdas vacías";
    }

    // ═══════════════════════ RESOLUCIÓN Y ANIMACIÓN ═══════════════════════

    private async void BtnResolver_Click(object? sender, EventArgs e)
    {
        var estrategia = rbMenosCandidatos.Checked ? Estrategia.MenosCandidatos : Estrategia.Secuencial;
        bool animar = chkAnimar.Checked;
        var copia = Sudoku.Clonar(_inicial);
        var pasos = animar ? new List<Paso>() : null;
        var metricas = new Metricas();
        int vacias = Sudoku.ContarVacias(copia);

        HabilitarControles(false);
        btnReiniciar.Enabled = false;
        lblEstado.Text = "Resolviendo...";

        try
        {
            double ms = 0;
            bool resuelto = await Task.Run(() =>       // en otro hilo para no congelar la ventana
            {
                var reloj = Stopwatch.StartNew();
                bool r = Sudoku.Resolver(copia, estrategia, metricas, pasos);
                ms = reloj.Elapsed.TotalMilliseconds;
                return r;
            });

            MostrarMetricas(estrategia, vacias, metricas, ms);
            btnReiniciar.Enabled = true;

            if (!resuelto)
            {
                HabilitarControles(true);
                string motivo = metricas.Agotado
                    ? $"Se alcanzó el límite de {metricas.LimiteLlamadas:N0} llamadas."
                    : "El tablero no tiene solución.";
                lblEstado.Text = motivo;
                MessageBox.Show(motivo, "Sin solución", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _solucion = copia;
            lblEstado.Text = $"Resuelto con {metricas.Llamadas:N0} llamadas y {metricas.Retrocesos:N0} retrocesos";

            if (animar)
            {
                _pasos = pasos!;
                _indicePaso = 0;
                _tablero = Sudoku.Clonar(_inicial);
                tmrAnimacion.Start();            // los controles se habilitan al terminar
            }
            else
            {
                _tablero = Sudoku.Clonar(copia);
                HabilitarControles(true);
                picTablero.Invalidate();
            }
        }
        catch (ArgumentException ex)
        {
            HabilitarControles(true);
            btnReiniciar.Enabled = true;
            lblEstado.Text = "Tablero no válido";
            MessageBox.Show(ex.Message, "Tablero no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void TmrAnimacion_Tick(object? sender, EventArgs e)
    {
        int cantidad = PasosPorTick[trkVelocidad.Value - 1];
        for (int k = 0; k < cantidad && _indicePaso < _pasos.Count; k++)
        {
            Paso p = _pasos[_indicePaso++];
            _tablero[p.Fila, p.Columna] = p.Valor;
            _ultimo = p;
        }

        lblEstado.Text = $"Animando paso {_indicePaso:N0} de {_pasos.Count:N0}";
        if (_indicePaso >= _pasos.Count)
            TerminarAnimacion();

        picTablero.Invalidate();
    }

    private void TerminarAnimacion()
    {
        tmrAnimacion.Stop();
        if (_solucion is not null)
            _tablero = Sudoku.Clonar(_solucion);   // por si la lista de pasos se recortó
        _ultimo = null;
        HabilitarControles(true);
        lblEstado.Text = "Animación terminada: tablero resuelto";
    }

    private void BtnReiniciar_Click(object? sender, EventArgs e)
    {
        tmrAnimacion.Stop();
        _tablero = Sudoku.Clonar(_inicial);
        _ultimo = null;
        HabilitarControles(true);
        picTablero.Invalidate();
        lblEstado.Text = "Tablero reiniciado";
    }

    // ═══════════════════════ EXPERIMENTOS ═══════════════════════

    private async void BtnExperimentos_Click(object? sender, EventArgs e)
    {
        int repeticiones = (int)nudRepeticiones.Value;
        HabilitarControles(false);
        btnReiniciar.Enabled = false;
        dgvExperimentos.Rows.Clear();
        var progreso = new Progress<int>(p =>
        {
            pgbExperimentos.Value = p;
            lblProgreso.Text = $"{p} %";
        });

        try
        {
            var reloj = Stopwatch.StartNew();
            _resultados = await Task.Run(() => Experimentos.Ejecutar(repeticiones, progreso));
            reloj.Stop();

            foreach (var r in _resultados)
                dgvExperimentos.Rows.Add(r.CeldasVacias, Sudoku.Nombre(r.Estrategia), $"{r.Llamadas:N0}",
                    $"{r.Retrocesos:N0}", r.ProfundidadMaxima, $"{r.Milisegundos:0.000}", r.LimitesAlcanzados);

            lblEstado.Text = $"Experimentos terminados en {reloj.Elapsed.TotalSeconds:0.0} s " +
                             $"({_resultados.Count} filas, semilla {Experimentos.Semilla})";
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Dato no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            HabilitarControles(true);
            btnReiniciar.Enabled = true;
            picGrafica.Invalidate();
        }
    }

    // ═══════════════════════ DIBUJO ═══════════════════════

    private float TamanoCelda() =>
        (Math.Min(picTablero.Width, picTablero.Height) - 2 * Margen) / Sudoku.N;

    private void PicTablero_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        float celda = TamanoCelda();

        for (int f = 0; f < Sudoku.N; f++)
            for (int c = 0; c < Sudoku.N; c++)
            {
                var rect = new RectangleF(Margen + c * celda, Margen + f * celda, celda, celda);
                _pincel.Color = ColorFondo(f, c);
                g.FillRectangle(_pincel, rect);

                int v = _tablero[f, c];
                if (v == 0)
                    continue;

                bool fija = _inicial[f, c] != 0;
                TextRenderer.DrawText(g, v.ToString(), fija ? _fuenteFija : _fuenteNormal, Rectangle.Round(rect),
                    fija ? Color.Black : Color.FromArgb(0, 90, 200),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

        float fin = Margen + Sudoku.N * celda;
        for (int i = 0; i <= Sudoku.N; i++)
        {
            Pen lapiz = i % 3 == 0 ? _lapizGrueso : _lapizDelgado;
            float p = Margen + i * celda;
            g.DrawLine(lapiz, p, Margen, p, fin);
            g.DrawLine(lapiz, Margen, p, fin, p);
        }
    }

    private Color ColorFondo(int f, int c)
    {
        if (_ultimo is Paso p && p.Fila == f && p.Columna == c)
            return p.Valor == 0 ? Color.FromArgb(255, 205, 205) : Color.FromArgb(200, 240, 200);
        if (_seleccion == (f, c))
            return Color.FromArgb(255, 243, 176);

        return (f / 3 + c / 3) % 2 == 0 ? Color.FromArgb(242, 245, 250) : Color.White;
    }

    /// <summary>Gráfica de líneas: llamadas promedio vs. celdas vacías, en escala logarítmica.</summary>
    private void PicGrafica_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        if (_resultados.Count == 0)
        {
            TextRenderer.DrawText(g, "Ejecuta los experimentos para ver la gráfica.", Font,
                picGrafica.ClientRectangle, Color.Gray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            return;
        }

        var area = new Rectangle(80, 30, picGrafica.Width - 110, picGrafica.Height - 70);
        int n = Experimentos.CeldasVacias.Length;
        double maxLog = Math.Ceiling(Math.Log10(Math.Max(10, _resultados.Max(r => r.Llamadas))));

        float X(int i) => area.Left + i * area.Width / (float)(n - 1);
        float Y(double llamadas) => area.Bottom - (float)(Math.Log10(Math.Max(1, llamadas)) / maxLog * area.Height);

        // Cuadrícula y etiquetas del eje Y (potencias de 10)
        using var lapizRejilla = new Pen(Color.Gainsboro);
        for (int p = 0; p <= maxLog; p++)
        {
            float y = Y(Math.Pow(10, p));
            g.DrawLine(lapizRejilla, area.Left, y, area.Right, y);
            TextRenderer.DrawText(g, $"{Math.Pow(10, p):N0}", Font,
                new Rectangle(0, (int)y - 9, area.Left - 6, 18), Color.DimGray, TextFormatFlags.Right);
        }
        g.DrawRectangle(Pens.Gray, area);

        // Eje X
        for (int i = 0; i < n; i++)
            TextRenderer.DrawText(g, Experimentos.CeldasVacias[i].ToString(), Font,
                new Point((int)X(i) - 8, area.Bottom + 4), Color.DimGray);

        TextRenderer.DrawText(g, "Llamadas recursivas promedio (escala logarítmica)", Font, new Point(area.Left, 6), Color.Black);
        TextRenderer.DrawText(g, "Celdas vacías = profundidad de la recursión", Font,
            new Rectangle(area.Left, area.Bottom + 22, area.Width, 18), Color.Black, TextFormatFlags.HorizontalCenter);

        DibujarSerie(Estrategia.Secuencial, Color.FromArgb(230, 120, 30), 0);
        DibujarSerie(Estrategia.MenosCandidatos, Color.FromArgb(0, 110, 200), 1);

        void DibujarSerie(Estrategia estrategia, Color color, int indiceLeyenda)
        {
            PointF[] puntos = _resultados
                .Where(r => r.Estrategia == estrategia)
                .Select(r => new PointF(X(Array.IndexOf(Experimentos.CeldasVacias, r.CeldasVacias)), Y(r.Llamadas)))
                .ToArray();

            using var lapiz = new Pen(color, 2.5F);
            using var pincel = new SolidBrush(color);
            if (puntos.Length > 1)
                g.DrawLines(lapiz, puntos);
            foreach (var pt in puntos)
                g.FillEllipse(pincel, pt.X - 4, pt.Y - 4, 8, 8);

            // Leyenda
            int ly = area.Top + 8 + indiceLeyenda * 20;
            g.FillRectangle(pincel, area.Left + 10, ly + 4, 14, 8);
            TextRenderer.DrawText(g, Sudoku.Nombre(estrategia), Font, new Point(area.Left + 30, ly), Color.Black);
        }
    }

    // ═══════════════════════ APOYO ═══════════════════════

    private void MostrarMetricas(Estrategia estrategia, int vacias, Metricas m, double ms)
    {
        lblEstrategia.Text = Sudoku.Nombre(estrategia);
        lblVaciasValor.Text = vacias.ToString();
        lblLlamadas.Text = m.Llamadas.ToString("N0");
        lblRetrocesos.Text = m.Retrocesos.ToString("N0");
        lblProfundidad.Text = m.ProfundidadMaxima.ToString("N0");
        lblTiempo.Text = ms.ToString("0.000");
    }

    private void LimpiarMetricas()
    {
        foreach (var lbl in new[] { lblEstrategia, lblVaciasValor, lblLlamadas, lblRetrocesos, lblProfundidad, lblTiempo })
            lbl.Text = "—";
    }

    private void HabilitarControles(bool habilitar)
    {
        grpTablero.Enabled = grpEstrategia.Enabled = chkAnimar.Enabled = habilitar;
        btnResolver.Enabled = btnExperimentos.Enabled = nudRepeticiones.Enabled = habilitar;
        _ocupado = !habilitar;
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // Libera los recursos GDI creados por el formulario
        _fuenteFija.Dispose();
        _fuenteNormal.Dispose();
        _lapizGrueso.Dispose();
        _lapizDelgado.Dispose();
        _pincel.Dispose();
        base.OnFormClosed(e);
    }
}