using System.Diagnostics;

namespace SudokuRecursivo;

/// <summary>Un paso del backtracking para la animación. Valor = 0 significa retroceso.</summary>
public readonly record struct Paso(int Fila, int Columna, int Valor);

/// <summary>Promedios de un grupo de experimentos con la misma cantidad de celdas vacías.</summary>
public record ResultadoExperimento(int CeldasVacias, Estrategia Estrategia, double Llamadas,
                                   double Retrocesos, int ProfundidadMaxima, double Milisegundos,
                                   int LimitesAlcanzados);

/// <summary>
/// Contadores de una ejecución recursiva: llamadas, retrocesos y profundidad máxima de la pila.
/// Incluye un límite de llamadas para que un tablero patológico no congele el programa.
/// </summary>
public class Metricas
{
    public const long LimitePorDefecto = 5_000_000;

    public Metricas(long limiteLlamadas = LimitePorDefecto) => LimiteLlamadas = limiteLlamadas;

    public long LimiteLlamadas { get; }
    public long Llamadas { get; private set; }
    public long Retrocesos { get; private set; }
    public int ProfundidadMaxima { get; private set; }
    public bool Agotado { get; private set; }

    /// <summary>Registra una llamada. Devuelve false si ya se alcanzó el límite.</summary>
    public bool Entrar(int profundidad)
    {
        if (Llamadas >= LimiteLlamadas)
        {
            Agotado = true;
            return false;
        }

        Llamadas++;
        if (profundidad > ProfundidadMaxima)
            ProfundidadMaxima = profundidad;

        return true;
    }

    public void Retroceder() => Retrocesos++;
}

/// <summary>
/// Mide el comportamiento del backtracking con distintas profundidades de llamada
/// (cantidad de celdas vacías) y con las dos estrategias.
/// </summary>
public static class Experimentos
{
    public static readonly int[] CeldasVacias = { 10, 20, 30, 40, 45, 50, 55, 60, 64 };
    public const int Semilla = 2026;   // semilla fija → resultados reproducibles

    public static List<ResultadoExperimento> Ejecutar(int repeticiones, IProgress<int>? progreso = null)
    {
        if (repeticiones < 1 || repeticiones > 10)
            throw new ArgumentException("Las repeticiones deben estar entre 1 y 10.");

        var random = new Random(Semilla);
        var resultados = new List<ResultadoExperimento>();
        var estrategias = Enum.GetValues<Estrategia>();
        int total = CeldasVacias.Length * repeticiones, hechos = 0;

        foreach (int vacias in CeldasVacias)
        {
            var llamadas = new long[2];
            var retrocesos = new long[2];
            var profundidad = new int[2];
            var milisegundos = new double[2];
            var limites = new int[2];

            for (int r = 0; r < repeticiones; r++)
            {
                int[,] puzzle = Sudoku.GenerarPuzzle(vacias, random);

                foreach (Estrategia e in estrategias)   // las dos estrategias resuelven el MISMO tablero
                {
                    int i = (int)e;
                    var metricas = new Metricas();
                    var reloj = Stopwatch.StartNew();
                    Sudoku.Resolver(Sudoku.Clonar(puzzle), e, metricas);
                    reloj.Stop();

                    llamadas[i] += metricas.Llamadas;
                    retrocesos[i] += metricas.Retrocesos;
                    profundidad[i] = Math.Max(profundidad[i], metricas.ProfundidadMaxima);
                    milisegundos[i] += reloj.Elapsed.TotalMilliseconds;
                    if (metricas.Agotado) limites[i]++;
                }

                progreso?.Report(++hechos * 100 / total);
            }

            foreach (Estrategia e in estrategias)
            {
                int i = (int)e;
                resultados.Add(new ResultadoExperimento(vacias, e,
                    (double)llamadas[i] / repeticiones, (double)retrocesos[i] / repeticiones,
                    profundidad[i], milisegundos[i] / repeticiones, limites[i]));
            }
        }
        return resultados;
    }
}
