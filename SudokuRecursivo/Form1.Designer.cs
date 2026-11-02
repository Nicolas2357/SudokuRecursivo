namespace SudokuRecursivo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle estiloEncabezado = new DataGridViewCellStyle();
            pnlEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlLateral = new Panel();
            btnReiniciar = new Button();
            btnResolver = new Button();
            grpAnimacion = new GroupBox();
            trkVelocidad = new TrackBar();
            lblVelocidad = new Label();
            chkAnimar = new CheckBox();
            grpEstrategia = new GroupBox();
            rbMenosCandidatos = new RadioButton();
            rbSecuencial = new RadioButton();
            grpTablero = new GroupBox();
            lblAyuda = new Label();
            btnCargar = new Button();
            nudVacias = new NumericUpDown();
            lblVacias = new Label();
            cmbPuzzle = new ComboBox();
            lblPuzzle = new Label();
            tabResultados = new TabControl();
            tabSudoku = new TabPage();
            lblLeyenda = new Label();
            grpMetricas = new GroupBox();
            lblTiempo = new Label();
            lblTitTiempo = new Label();
            lblProfundidad = new Label();
            lblTitProfundidad = new Label();
            lblRetrocesos = new Label();
            lblTitRetrocesos = new Label();
            lblLlamadas = new Label();
            lblTitLlamadas = new Label();
            lblVaciasValor = new Label();
            lblTitVacias = new Label();
            lblEstrategia = new Label();
            lblTitEstrategia = new Label();
            picTablero = new PictureBox();
            tabExperimentos = new TabPage();
            dgvExperimentos = new DataGridView();
            colVacias = new DataGridViewTextBoxColumn();
            colEstrategia = new DataGridViewTextBoxColumn();
            colLlamadas = new DataGridViewTextBoxColumn();
            colRetrocesos = new DataGridViewTextBoxColumn();
            colProfundidad = new DataGridViewTextBoxColumn();
            colTiempo = new DataGridViewTextBoxColumn();
            colLimite = new DataGridViewTextBoxColumn();
            picGrafica = new PictureBox();
            pnlBarraExp = new Panel();
            lblProgreso = new Label();
            pgbExperimentos = new ProgressBar();
            btnExperimentos = new Button();
            nudRepeticiones = new NumericUpDown();
            lblRepeticiones = new Label();
            statusStrip = new StatusStrip();
            lblEstado = new ToolStripStatusLabel();
            tmrAnimacion = new System.Windows.Forms.Timer(components);
            pnlEncabezado.SuspendLayout();
            pnlLateral.SuspendLayout();
            grpAnimacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkVelocidad).BeginInit();
            grpEstrategia.SuspendLayout();
            grpTablero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudVacias).BeginInit();
            tabResultados.SuspendLayout();
            tabSudoku.SuspendLayout();
            grpMetricas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTablero).BeginInit();
            tabExperimentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExperimentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picGrafica).BeginInit();
            pnlBarraExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(31, 58, 96);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1000, 68);
            pnlEncabezado.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(18, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(330, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sudoku con backtracking recursivo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.75F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 215, 235);
            lblSubtitulo.Location = new Point(21, 40);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(430, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Implementación de casos recursivos y análisis de profundidad  •  Estructura de Datos";
            // 
            // pnlLateral
            // 
            pnlLateral.BackColor = Color.FromArgb(240, 243, 248);
            pnlLateral.Controls.Add(btnReiniciar);
            pnlLateral.Controls.Add(btnResolver);
            pnlLateral.Controls.Add(grpAnimacion);
            pnlLateral.Controls.Add(grpEstrategia);
            pnlLateral.Controls.Add(grpTablero);
            pnlLateral.Dock = DockStyle.Left;
            pnlLateral.Location = new Point(0, 68);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(300, 570);
            pnlLateral.TabIndex = 1;
            // 
            // grpTablero
            // 
            grpTablero.Controls.Add(lblAyuda);
            grpTablero.Controls.Add(btnCargar);
            grpTablero.Controls.Add(nudVacias);
            grpTablero.Controls.Add(lblVacias);
            grpTablero.Controls.Add(cmbPuzzle);
            grpTablero.Controls.Add(lblPuzzle);
            grpTablero.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpTablero.ForeColor = Color.FromArgb(31, 58, 96);
            grpTablero.Location = new Point(12, 12);
            grpTablero.Name = "grpTablero";
            grpTablero.Size = new Size(276, 188);
            grpTablero.TabIndex = 0;
            grpTablero.TabStop = false;
            grpTablero.Text = "1. Tablero";
            // 
            // lblPuzzle
            // 
            lblPuzzle.AutoSize = true;
            lblPuzzle.Font = new Font("Segoe UI", 9F);
            lblPuzzle.ForeColor = Color.Black;
            lblPuzzle.Location = new Point(12, 26);
            lblPuzzle.Name = "lblPuzzle";
            lblPuzzle.Size = new Size(110, 15);
            lblPuzzle.TabIndex = 0;
            lblPuzzle.Text = "Tablero de partida:";
            // 
            // cmbPuzzle
            // 
            cmbPuzzle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuzzle.Font = new Font("Segoe UI", 9.75F);
            cmbPuzzle.FormattingEnabled = true;
            cmbPuzzle.Location = new Point(12, 46);
            cmbPuzzle.Name = "cmbPuzzle";
            cmbPuzzle.Size = new Size(252, 25);
            cmbPuzzle.TabIndex = 1;
            cmbPuzzle.SelectedIndexChanged += CmbPuzzle_SelectedIndexChanged;
            // 
            // lblVacias
            // 
            lblVacias.AutoSize = true;
            lblVacias.Font = new Font("Segoe UI", 9F);
            lblVacias.ForeColor = Color.Black;
            lblVacias.Location = new Point(12, 85);
            lblVacias.Name = "lblVacias";
            lblVacias.Size = new Size(150, 15);
            lblVacias.TabIndex = 2;
            lblVacias.Text = "Celdas vacías (aleatorio):";
            // 
            // nudVacias
            // 
            nudVacias.Font = new Font("Segoe UI", 9F);
            nudVacias.Location = new Point(190, 82);
            nudVacias.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            nudVacias.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudVacias.Name = "nudVacias";
            nudVacias.Size = new Size(74, 23);
            nudVacias.TabIndex = 3;
            nudVacias.TextAlign = HorizontalAlignment.Center;
            nudVacias.Value = new decimal(new int[] { 45, 0, 0, 0 });
            // 
            // btnCargar
            // 
            btnCargar.Cursor = Cursors.Hand;
            btnCargar.Font = new Font("Segoe UI", 9F);
            btnCargar.ForeColor = Color.Black;
            btnCargar.Location = new Point(12, 116);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(252, 30);
            btnCargar.TabIndex = 4;
            btnCargar.Text = "Cargar tablero";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += BtnCargar_Click;
            // 
            // lblAyuda
            // 
            lblAyuda.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
            lblAyuda.ForeColor = Color.DimGray;
            lblAyuda.Location = new Point(12, 152);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(252, 30);
            lblAyuda.TabIndex = 5;
            lblAyuda.Text = "Para editar: clic en una celda y teclea 1–9 (Supr o 0 para borrar).";
            // 
            // grpEstrategia
            // 
            grpEstrategia.Controls.Add(rbMenosCandidatos);
            grpEstrategia.Controls.Add(rbSecuencial);
            grpEstrategia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpEstrategia.ForeColor = Color.FromArgb(31, 58, 96);
            grpEstrategia.Location = new Point(12, 208);
            grpEstrategia.Name = "grpEstrategia";
            grpEstrategia.Size = new Size(276, 84);
            grpEstrategia.TabIndex = 1;
            grpEstrategia.TabStop = false;
            grpEstrategia.Text = "2. Estrategia";
            // 
            // rbSecuencial
            // 
            rbSecuencial.AutoSize = true;
            rbSecuencial.Checked = true;
            rbSecuencial.Font = new Font("Segoe UI", 9F);
            rbSecuencial.ForeColor = Color.Black;
            rbSecuencial.Location = new Point(14, 26);
            rbSecuencial.Name = "rbSecuencial";
            rbSecuencial.Size = new Size(200, 19);
            rbSecuencial.TabIndex = 0;
            rbSecuencial.TabStop = true;
            rbSecuencial.Text = "Secuencial (primera celda vacía)";
            rbSecuencial.UseVisualStyleBackColor = true;
            // 
            // rbMenosCandidatos
            // 
            rbMenosCandidatos.AutoSize = true;
            rbMenosCandidatos.Font = new Font("Segoe UI", 9F);
            rbMenosCandidatos.ForeColor = Color.Black;
            rbMenosCandidatos.Location = new Point(14, 52);
            rbMenosCandidatos.Name = "rbMenosCandidatos";
            rbMenosCandidatos.Size = new Size(160, 19);
            rbMenosCandidatos.TabIndex = 1;
            rbMenosCandidatos.Text = "Menos candidatos (MRV)";
            rbMenosCandidatos.UseVisualStyleBackColor = true;
            // 
            // grpAnimacion
            // 
            grpAnimacion.Controls.Add(trkVelocidad);
            grpAnimacion.Controls.Add(lblVelocidad);
            grpAnimacion.Controls.Add(chkAnimar);
            grpAnimacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpAnimacion.ForeColor = Color.FromArgb(31, 58, 96);
            grpAnimacion.Location = new Point(12, 300);
            grpAnimacion.Name = "grpAnimacion";
            grpAnimacion.Size = new Size(276, 104);
            grpAnimacion.TabIndex = 2;
            grpAnimacion.TabStop = false;
            grpAnimacion.Text = "3. Animación";
            // 
            // chkAnimar
            // 
            chkAnimar.AutoSize = true;
            chkAnimar.Checked = true;
            chkAnimar.CheckState = CheckState.Checked;
            chkAnimar.Font = new Font("Segoe UI", 9F);
            chkAnimar.ForeColor = Color.Black;
            chkAnimar.Location = new Point(14, 26);
            chkAnimar.Name = "chkAnimar";
            chkAnimar.Size = new Size(160, 19);
            chkAnimar.TabIndex = 0;
            chkAnimar.Text = "Animar el backtracking";
            chkAnimar.UseVisualStyleBackColor = true;
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.Font = new Font("Segoe UI", 9F);
            lblVelocidad.ForeColor = Color.Black;
            lblVelocidad.Location = new Point(12, 60);
            lblVelocidad.Name = "lblVelocidad";
            lblVelocidad.Size = new Size(60, 15);
            lblVelocidad.TabIndex = 1;
            lblVelocidad.Text = "Velocidad:";
            // 
            // trkVelocidad
            // 
            trkVelocidad.Location = new Point(80, 52);
            trkVelocidad.Minimum = 1;
            trkVelocidad.Name = "trkVelocidad";
            trkVelocidad.Size = new Size(184, 45);
            trkVelocidad.TabIndex = 2;
            trkVelocidad.Value = 5;
            // 
            // btnResolver
            // 
            btnResolver.BackColor = Color.FromArgb(0, 120, 215);
            btnResolver.Cursor = Cursors.Hand;
            btnResolver.FlatAppearance.BorderSize = 0;
            btnResolver.FlatStyle = FlatStyle.Flat;
            btnResolver.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnResolver.ForeColor = Color.White;
            btnResolver.Location = new Point(12, 418);
            btnResolver.Name = "btnResolver";
            btnResolver.Size = new Size(276, 44);
            btnResolver.TabIndex = 3;
            btnResolver.Text = "▶  Resolver";
            btnResolver.UseVisualStyleBackColor = false;
            btnResolver.Click += BtnResolver_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Cursor = Cursors.Hand;
            btnReiniciar.FlatStyle = FlatStyle.Flat;
            btnReiniciar.Location = new Point(12, 470);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(276, 34);
            btnReiniciar.TabIndex = 4;
            btnReiniciar.Text = "Reiniciar tablero / detener animación";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += BtnReiniciar_Click;
            // 
            // tabResultados
            // 
            tabResultados.Controls.Add(tabSudoku);
            tabResultados.Controls.Add(tabExperimentos);
            tabResultados.Dock = DockStyle.Fill;
            tabResultados.Font = new Font("Segoe UI", 9.75F);
            tabResultados.Location = new Point(300, 68);
            tabResultados.Name = "tabResultados";
            tabResultados.Padding = new Point(12, 5);
            tabResultados.SelectedIndex = 0;
            tabResultados.Size = new Size(700, 570);
            tabResultados.TabIndex = 2;
            // 
            // tabSudoku
            // 
            tabSudoku.Controls.Add(lblLeyenda);
            tabSudoku.Controls.Add(grpMetricas);
            tabSudoku.Controls.Add(picTablero);
            tabSudoku.Location = new Point(4, 30);
            tabSudoku.Name = "tabSudoku";
            tabSudoku.Size = new Size(692, 536);
            tabSudoku.TabIndex = 0;
            tabSudoku.Text = "Tablero";
            tabSudoku.UseVisualStyleBackColor = true;
            // 
            // picTablero
            // 
            picTablero.BackColor = Color.White;
            picTablero.Cursor = Cursors.Hand;
            picTablero.Location = new Point(14, 14);
            picTablero.Name = "picTablero";
            picTablero.Size = new Size(458, 458);
            picTablero.TabIndex = 0;
            picTablero.TabStop = false;
            picTablero.Paint += PicTablero_Paint;
            picTablero.MouseClick += PicTablero_MouseClick;
            // 
            // grpMetricas
            // 
            grpMetricas.Controls.Add(lblTiempo);
            grpMetricas.Controls.Add(lblTitTiempo);
            grpMetricas.Controls.Add(lblProfundidad);
            grpMetricas.Controls.Add(lblTitProfundidad);
            grpMetricas.Controls.Add(lblRetrocesos);
            grpMetricas.Controls.Add(lblTitRetrocesos);
            grpMetricas.Controls.Add(lblLlamadas);
            grpMetricas.Controls.Add(lblTitLlamadas);
            grpMetricas.Controls.Add(lblVaciasValor);
            grpMetricas.Controls.Add(lblTitVacias);
            grpMetricas.Controls.Add(lblEstrategia);
            grpMetricas.Controls.Add(lblTitEstrategia);
            grpMetricas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpMetricas.ForeColor = Color.FromArgb(31, 58, 96);
            grpMetricas.Location = new Point(488, 8);
            grpMetricas.Name = "grpMetricas";
            grpMetricas.Size = new Size(192, 302);
            grpMetricas.TabIndex = 1;
            grpMetricas.TabStop = false;
            grpMetricas.Text = "Métricas de la recursión";
            // 
            // lblTitEstrategia
            // 
            lblTitEstrategia.AutoSize = true;
            lblTitEstrategia.Font = new Font("Segoe UI", 8.25F);
            lblTitEstrategia.ForeColor = Color.DimGray;
            lblTitEstrategia.Location = new Point(12, 24);
            lblTitEstrategia.Name = "lblTitEstrategia";
            lblTitEstrategia.Size = new Size(57, 13);
            lblTitEstrategia.TabIndex = 0;
            lblTitEstrategia.Text = "Estrategia";
            // 
            // lblEstrategia
            // 
            lblEstrategia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstrategia.ForeColor = Color.Black;
            lblEstrategia.Location = new Point(12, 40);
            lblEstrategia.Name = "lblEstrategia";
            lblEstrategia.Size = new Size(170, 22);
            lblEstrategia.TabIndex = 1;
            lblEstrategia.Text = "—";
            // 
            // lblTitVacias
            // 
            lblTitVacias.AutoSize = true;
            lblTitVacias.Font = new Font("Segoe UI", 8.25F);
            lblTitVacias.ForeColor = Color.DimGray;
            lblTitVacias.Location = new Point(12, 69);
            lblTitVacias.Name = "lblTitVacias";
            lblTitVacias.Size = new Size(150, 13);
            lblTitVacias.TabIndex = 2;
            lblTitVacias.Text = "Celdas vacías iniciales";
            // 
            // lblVaciasValor
            // 
            lblVaciasValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVaciasValor.ForeColor = Color.Black;
            lblVaciasValor.Location = new Point(12, 85);
            lblVaciasValor.Name = "lblVaciasValor";
            lblVaciasValor.Size = new Size(170, 22);
            lblVaciasValor.TabIndex = 3;
            lblVaciasValor.Text = "—";
            // 
            // lblTitLlamadas
            // 
            lblTitLlamadas.AutoSize = true;
            lblTitLlamadas.Font = new Font("Segoe UI", 8.25F);
            lblTitLlamadas.ForeColor = Color.DimGray;
            lblTitLlamadas.Location = new Point(12, 114);
            lblTitLlamadas.Name = "lblTitLlamadas";
            lblTitLlamadas.Size = new Size(110, 13);
            lblTitLlamadas.TabIndex = 4;
            lblTitLlamadas.Text = "Llamadas recursivas";
            // 
            // lblLlamadas
            // 
            lblLlamadas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLlamadas.ForeColor = Color.Black;
            lblLlamadas.Location = new Point(12, 130);
            lblLlamadas.Name = "lblLlamadas";
            lblLlamadas.Size = new Size(170, 22);
            lblLlamadas.TabIndex = 5;
            lblLlamadas.Text = "—";
            // 
            // lblTitRetrocesos
            // 
            lblTitRetrocesos.AutoSize = true;
            lblTitRetrocesos.Font = new Font("Segoe UI", 8.25F);
            lblTitRetrocesos.ForeColor = Color.DimGray;
            lblTitRetrocesos.Location = new Point(12, 159);
            lblTitRetrocesos.Name = "lblTitRetrocesos";
            lblTitRetrocesos.Size = new Size(130, 13);
            lblTitRetrocesos.TabIndex = 6;
            lblTitRetrocesos.Text = "Retrocesos (backtracking)";
            // 
            // lblRetrocesos
            // 
            lblRetrocesos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRetrocesos.ForeColor = Color.FromArgb(190, 40, 40);
            lblRetrocesos.Location = new Point(12, 175);
            lblRetrocesos.Name = "lblRetrocesos";
            lblRetrocesos.Size = new Size(170, 22);
            lblRetrocesos.TabIndex = 7;
            lblRetrocesos.Text = "—";
            // 
            // lblTitProfundidad
            // 
            lblTitProfundidad.AutoSize = true;
            lblTitProfundidad.Font = new Font("Segoe UI", 8.25F);
            lblTitProfundidad.ForeColor = Color.DimGray;
            lblTitProfundidad.Location = new Point(12, 204);
            lblTitProfundidad.Name = "lblTitProfundidad";
            lblTitProfundidad.Size = new Size(150, 13);
            lblTitProfundidad.TabIndex = 8;
            lblTitProfundidad.Text = "Profundidad máxima de pila";
            // 
            // lblProfundidad
            // 
            lblProfundidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfundidad.ForeColor = Color.Black;
            lblProfundidad.Location = new Point(12, 220);
            lblProfundidad.Name = "lblProfundidad";
            lblProfundidad.Size = new Size(170, 22);
            lblProfundidad.TabIndex = 9;
            lblProfundidad.Text = "—";
            // 
            // lblTitTiempo
            // 
            lblTitTiempo.AutoSize = true;
            lblTitTiempo.Font = new Font("Segoe UI", 8.25F);
            lblTitTiempo.ForeColor = Color.DimGray;
            lblTitTiempo.Location = new Point(12, 249);
            lblTitTiempo.Name = "lblTitTiempo";
            lblTitTiempo.Size = new Size(70, 13);
            lblTitTiempo.TabIndex = 10;
            lblTitTiempo.Text = "Tiempo (ms)";
            // 
            // lblTiempo
            // 
            lblTiempo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTiempo.ForeColor = Color.Black;
            lblTiempo.Location = new Point(12, 265);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(170, 22);
            lblTiempo.TabIndex = 11;
            lblTiempo.Text = "—";
            // 
            // lblLeyenda
            // 
            lblLeyenda.Font = new Font("Segoe UI", 9F);
            lblLeyenda.ForeColor = Color.FromArgb(60, 60, 60);
            lblLeyenda.Location = new Point(490, 322);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(190, 120);
            lblLeyenda.TabIndex = 2;
            lblLeyenda.Text = "Leyenda:\r\n• Negro: números iniciales\r\n• Azul: números colocados\r\n• Fondo verde: último intento\r\n• Fondo rojo: retroceso\r\n• Fondo amarillo: celda seleccionada";
            // 
            // tabExperimentos
            // 
            tabExperimentos.Controls.Add(dgvExperimentos);
            tabExperimentos.Controls.Add(picGrafica);
            tabExperimentos.Controls.Add(pnlBarraExp);
            tabExperimentos.Location = new Point(4, 30);
            tabExperimentos.Name = "tabExperimentos";
            tabExperimentos.Padding = new Padding(8);
            tabExperimentos.Size = new Size(692, 536);
            tabExperimentos.TabIndex = 1;
            tabExperimentos.Text = "Experimentos de profundidad";
            tabExperimentos.UseVisualStyleBackColor = true;
            // 
            // pnlBarraExp
            // 
            pnlBarraExp.Controls.Add(lblProgreso);
            pnlBarraExp.Controls.Add(pgbExperimentos);
            pnlBarraExp.Controls.Add(btnExperimentos);
            pnlBarraExp.Controls.Add(nudRepeticiones);
            pnlBarraExp.Controls.Add(lblRepeticiones);
            pnlBarraExp.Dock = DockStyle.Top;
            pnlBarraExp.Location = new Point(8, 8);
            pnlBarraExp.Name = "pnlBarraExp";
            pnlBarraExp.Size = new Size(676, 48);
            pnlBarraExp.TabIndex = 0;
            // 
            // lblRepeticiones
            // 
            lblRepeticiones.AutoSize = true;
            lblRepeticiones.Font = new Font("Segoe UI", 9F);
            lblRepeticiones.Location = new Point(2, 16);
            lblRepeticiones.Name = "lblRepeticiones";
            lblRepeticiones.Size = new Size(140, 15);
            lblRepeticiones.TabIndex = 0;
            lblRepeticiones.Text = "Repeticiones por tamaño:";
            // 
            // nudRepeticiones
            // 
            nudRepeticiones.Font = new Font("Segoe UI", 9F);
            nudRepeticiones.Location = new Point(150, 13);
            nudRepeticiones.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudRepeticiones.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRepeticiones.Name = "nudRepeticiones";
            nudRepeticiones.Size = new Size(56, 23);
            nudRepeticiones.TabIndex = 1;
            nudRepeticiones.TextAlign = HorizontalAlignment.Center;
            nudRepeticiones.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnExperimentos
            // 
            btnExperimentos.BackColor = Color.FromArgb(0, 120, 215);
            btnExperimentos.Cursor = Cursors.Hand;
            btnExperimentos.FlatAppearance.BorderSize = 0;
            btnExperimentos.FlatStyle = FlatStyle.Flat;
            btnExperimentos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExperimentos.ForeColor = Color.White;
            btnExperimentos.Location = new Point(220, 8);
            btnExperimentos.Name = "btnExperimentos";
            btnExperimentos.Size = new Size(200, 32);
            btnExperimentos.TabIndex = 2;
            btnExperimentos.Text = "▶  Ejecutar experimentos";
            btnExperimentos.UseVisualStyleBackColor = false;
            btnExperimentos.Click += BtnExperimentos_Click;
            // 
            // pgbExperimentos
            // 
            pgbExperimentos.Location = new Point(434, 12);
            pgbExperimentos.Name = "pgbExperimentos";
            pgbExperimentos.Size = new Size(150, 24);
            pgbExperimentos.TabIndex = 3;
            // 
            // lblProgreso
            // 
            lblProgreso.AutoSize = true;
            lblProgreso.Font = new Font("Segoe UI", 9F);
            lblProgreso.Location = new Point(592, 16);
            lblProgreso.Name = "lblProgreso";
            lblProgreso.Size = new Size(23, 15);
            lblProgreso.TabIndex = 4;
            lblProgreso.Text = "0 %";
            // 
            // dgvExperimentos
            // 
            dgvExperimentos.AllowUserToAddRows = false;
            dgvExperimentos.AllowUserToDeleteRows = false;
            dgvExperimentos.AllowUserToResizeRows = false;
            dgvExperimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExperimentos.BackgroundColor = Color.White;
            dgvExperimentos.BorderStyle = BorderStyle.None;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleCenter;
            estiloEncabezado.BackColor = Color.FromArgb(31, 58, 96);
            estiloEncabezado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.White;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(31, 58, 96);
            estiloEncabezado.SelectionForeColor = Color.White;
            estiloEncabezado.WrapMode = DataGridViewTriState.True;
            dgvExperimentos.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvExperimentos.ColumnHeadersHeight = 40;
            dgvExperimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvExperimentos.Columns.AddRange(new DataGridViewColumn[] { colVacias, colEstrategia, colLlamadas, colRetrocesos, colProfundidad, colTiempo, colLimite });
            dgvExperimentos.Dock = DockStyle.Fill;
            dgvExperimentos.EnableHeadersVisualStyles = false;
            dgvExperimentos.Font = new Font("Segoe UI", 9F);
            dgvExperimentos.Location = new Point(8, 56);
            dgvExperimentos.Name = "dgvExperimentos";
            dgvExperimentos.ReadOnly = true;
            dgvExperimentos.RowHeadersVisible = false;
            dgvExperimentos.RowTemplate.Height = 24;
            dgvExperimentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExperimentos.Size = new Size(676, 232);
            dgvExperimentos.TabIndex = 1;
            // 
            // colVacias
            // 
            colVacias.FillWeight = 70F;
            colVacias.HeaderText = "Celdas vacías";
            colVacias.Name = "colVacias";
            colVacias.ReadOnly = true;
            // 
            // colEstrategia
            // 
            colEstrategia.FillWeight = 150F;
            colEstrategia.HeaderText = "Estrategia";
            colEstrategia.Name = "colEstrategia";
            colEstrategia.ReadOnly = true;
            // 
            // colLlamadas
            // 
            colLlamadas.HeaderText = "Llamadas (prom.)";
            colLlamadas.Name = "colLlamadas";
            colLlamadas.ReadOnly = true;
            // 
            // colRetrocesos
            // 
            colRetrocesos.HeaderText = "Retrocesos (prom.)";
            colRetrocesos.Name = "colRetrocesos";
            colRetrocesos.ReadOnly = true;
            // 
            // colProfundidad
            // 
            colProfundidad.FillWeight = 80F;
            colProfundidad.HeaderText = "Profundidad máx.";
            colProfundidad.Name = "colProfundidad";
            colProfundidad.ReadOnly = true;
            // 
            // colTiempo
            // 
            colTiempo.FillWeight = 90F;
            colTiempo.HeaderText = "Tiempo prom. (ms)";
            colTiempo.Name = "colTiempo";
            colTiempo.ReadOnly = true;
            // 
            // colLimite
            // 
            colLimite.FillWeight = 70F;
            colLimite.HeaderText = "Límite alcanzado";
            colLimite.Name = "colLimite";
            colLimite.ReadOnly = true;
            // 
            // picGrafica
            // 
            picGrafica.BackColor = Color.White;
            picGrafica.Dock = DockStyle.Bottom;
            picGrafica.Location = new Point(8, 288);
            picGrafica.Name = "picGrafica";
            picGrafica.Size = new Size(676, 240);
            picGrafica.TabIndex = 2;
            picGrafica.TabStop = false;
            picGrafica.Paint += PicGrafica_Paint;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblEstado });
            statusStrip.Location = new Point(0, 638);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1000, 22);
            statusStrip.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(35, 17);
            lblEstado.Text = "Listo";
            // 
            // tmrAnimacion
            // 
            tmrAnimacion.Interval = 15;
            tmrAnimacion.Tick += TmrAnimacion_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 660);
            Controls.Add(tabResultados);
            Controls.Add(pnlLateral);
            Controls.Add(pnlEncabezado);
            Controls.Add(statusStrip);
            KeyPreview = true;
            MinimumSize = new Size(1016, 699);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sudoku recursivo – Backtracking y análisis de profundidad";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlLateral.ResumeLayout(false);
            grpAnimacion.ResumeLayout(false);
            grpAnimacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkVelocidad).EndInit();
            grpEstrategia.ResumeLayout(false);
            grpEstrategia.PerformLayout();
            grpTablero.ResumeLayout(false);
            grpTablero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudVacias).EndInit();
            tabResultados.ResumeLayout(false);
            tabSudoku.ResumeLayout(false);
            grpMetricas.ResumeLayout(false);
            grpMetricas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picTablero).EndInit();
            tabExperimentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExperimentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)picGrafica).EndInit();
            pnlBarraExp.ResumeLayout(false);
            pnlBarraExp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlLateral;
        private GroupBox grpTablero;
        private Label lblPuzzle;
        private ComboBox cmbPuzzle;
        private Label lblVacias;
        private NumericUpDown nudVacias;
        private Button btnCargar;
        private Label lblAyuda;
        private GroupBox grpEstrategia;
        private RadioButton rbSecuencial;
        private RadioButton rbMenosCandidatos;
        private GroupBox grpAnimacion;
        private CheckBox chkAnimar;
        private Label lblVelocidad;
        private TrackBar trkVelocidad;
        private Button btnResolver;
        private Button btnReiniciar;
        private TabControl tabResultados;
        private TabPage tabSudoku;
        private PictureBox picTablero;
        private GroupBox grpMetricas;
        private Label lblTitEstrategia;
        private Label lblEstrategia;
        private Label lblTitVacias;
        private Label lblVaciasValor;
        private Label lblTitLlamadas;
        private Label lblLlamadas;
        private Label lblTitRetrocesos;
        private Label lblRetrocesos;
        private Label lblTitProfundidad;
        private Label lblProfundidad;
        private Label lblTitTiempo;
        private Label lblTiempo;
        private Label lblLeyenda;
        private TabPage tabExperimentos;
        private Panel pnlBarraExp;
        private Label lblRepeticiones;
        private NumericUpDown nudRepeticiones;
        private Button btnExperimentos;
        private ProgressBar pgbExperimentos;
        private Label lblProgreso;
        private DataGridView dgvExperimentos;
        private DataGridViewTextBoxColumn colVacias;
        private DataGridViewTextBoxColumn colEstrategia;
        private DataGridViewTextBoxColumn colLlamadas;
        private DataGridViewTextBoxColumn colRetrocesos;
        private DataGridViewTextBoxColumn colProfundidad;
        private DataGridViewTextBoxColumn colTiempo;
        private DataGridViewTextBoxColumn colLimite;
        private PictureBox picGrafica;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.Timer tmrAnimacion;
    }
}