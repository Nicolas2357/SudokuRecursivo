namespace SudokuRecursivo;

/// <summary>Forma de elegir la siguiente celda vacía en el backtracking.</summary>
public enum Estrategia
{
    Secuencial,        // la primera celda vacía, de izquierda a derecha y de arriba abajo
    MenosCandidatos    // la celda con menos números posibles (heurística MRV)
}

/// <summary>
/// Lógica del Sudoku: validación, resolución por backtracking recursivo
/// y generación recursiva de tableros aleatorios.
/// </summary>
public static class Sudoku
{
    public const int N = 9;
    public const int MinVacias = 10;
    public const int MaxVacias = 64;
    private const int MaxPasos = 300_000;   // tope de pasos guardados para la animación

    // ═══════════════════════ RESOLUCIÓN (BACKTRACKING) ═══════════════════════

    /// <summary>
    /// Resuelve el tablero en el mismo arreglo. Devuelve false si no tiene solución
    /// o si se alcanzó el límite de llamadas de <paramref name="metricas"/>.
    /// </summary>
    public static bool Resolver(int[,] tablero, Estrategia estrategia, Metricas metricas, List<Paso>? pasos = null)
    {
        ValidarTablero(tablero);
        ArgumentNullException.ThrowIfNull(metricas);
        return Resolver(tablero, estrategia, 1, metricas, pasos);
    }

    private static bool Resolver(int[,] t, Estrategia estrategia, int prof, Metricas m, List<Paso>? pasos)
    {
        if (!m.Entrar(prof))
            return false;                                     // se alcanzó el límite de llamadas

        var (fila, col) = estrategia == Estrategia.Secuencial
            ? PrimeraVacia(t)
            : CeldaConMenosCandidatos(t);

        if (fila == -1)
            return true;                                      // CASO BASE 1: no hay celdas vacías → resuelto

        for (int v = 1; v <= N; v++)
        {
            if (!EsValido(t, fila, col, v))
                continue;

            t[fila, col] = v;                                 // intenta colocar v
            Registrar(pasos, new Paso(fila, col, v));

            if (Resolver(t, estrategia, prof + 1, m, pasos))  // CASO RECURSIVO: resolver el resto
                return true;

            t[fila, col] = 0;                                 // BACKTRACKING: deshace el intento
            if (m.Agotado)
                return false;

            m.Retroceder();
            Registrar(pasos, new Paso(fila, col, 0));
        }

        return false;                                         // CASO BASE 2: ningún número cabe → callejón sin salida
    }

    private static (int Fila, int Col) PrimeraVacia(int[,] t)
    {
        for (int f = 0; f < N; f++)
            for (int c = 0; c < N; c++)
                if (t[f, c] == 0)
                    return (f, c);

        return (-1, -1);
    }

    /// <summary>Heurística MRV: elige la celda vacía con menos números posibles.</summary>
    private static (int Fila, int Col) CeldaConMenosCandidatos(int[,] t)
    {
        (int, int) mejor = (-1, -1);
        int menor = N + 1;

        for (int f = 0; f < N; f++)
            for (int c = 0; c < N; c++)
            {
                if (t[f, c] != 0)
                    continue;

                int candidatos = ContarCandidatos(t, f, c);
                if (candidatos < menor)
                {
                    menor = candidatos;
                    mejor = (f, c);
                    if (candidatos <= 1)       // 0 = callejón inmediato, 1 = jugada forzada
                        return mejor;
                }
            }

        return mejor;
    }

    private static int ContarCandidatos(int[,] t, int fila, int col)
    {
        int total = 0;
        for (int v = 1; v <= N; v++)
            if (EsValido(t, fila, col, v))
                total++;

        return total;
    }

    private static void Registrar(List<Paso>? pasos, Paso paso)
    {
        if (pasos is not null && pasos.Count < MaxPasos)
            pasos.Add(paso);
    }

    // ═══════════════════════ GENERACIÓN (también recursiva) ═══════════════════════

    /// <summary>Genera un tablero completo y válido al azar.</summary>
    public static int[,] GenerarCompleto(Random random)
    {
        var t = new int[N, N];
        Llenar(t, 0, random);
        return t;
    }

    private static bool Llenar(int[,] t, int pos, Random random)
    {
        if (pos == N * N)
            return true;                                      // CASO BASE: tablero lleno

        int f = pos / N, c = pos % N;
        int[] digitos = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        random.Shuffle(digitos);                              // orden aleatorio → tableros distintos

        foreach (int v in digitos)
        {
            if (!EsValido(t, f, c, v))
                continue;

            t[f, c] = v;
            if (Llenar(t, pos + 1, random))                   // CASO RECURSIVO: siguiente celda
                return true;

            t[f, c] = 0;                                      // retroceso
        }
        return false;
    }

    /// <summary>Genera un tablero completo y le borra <paramref name="celdasVacias"/> celdas al azar.</summary>
    public static int[,] GenerarPuzzle(int celdasVacias, Random random)
    {
        if (celdasVacias < MinVacias || celdasVacias > MaxVacias)
            throw new ArgumentException($"Las celdas vacías deben estar entre {MinVacias} y {MaxVacias}.");

        int[,] t = GenerarCompleto(random);
        int[] posiciones = Enumerable.Range(0, N * N).ToArray();
        random.Shuffle(posiciones);

        for (int i = 0; i < celdasVacias; i++)
            t[posiciones[i] / N, posiciones[i] % N] = 0;

        return t;
    }

    // ═══════════════════════ UTILIDADES Y VALIDACIÓN ═══════════════════════

    /// <summary>Indica si v puede ir en (fila, col) sin repetirse en su fila, columna o cuadro de 3×3.</summary>
    public static bool EsValido(int[,] t, int fila, int col, int v)
    {
        for (int i = 0; i < N; i++)
            if (t[fila, i] == v || t[i, col] == v)
                return false;

        int f0 = fila - fila % 3, c0 = col - col % 3;
        for (int f = f0; f < f0 + 3; f++)
            for (int c = c0; c < c0 + 3; c++)
                if (t[f, c] == v)
                    return false;

        return true;
    }

    /// <summary>Verifica que el tablero sea de 9×9, con valores de 0 a 9 y sin números repetidos.</summary>
    public static void ValidarTablero(int[,] t)
    {
        ArgumentNullException.ThrowIfNull(t);
        if (t.GetLength(0) != N || t.GetLength(1) != N)
            throw new ArgumentException("El tablero debe ser de 9×9.");

        for (int f = 0; f < N; f++)
            for (int c = 0; c < N; c++)
            {
                int v = t[f, c];
                if (v == 0)
                    continue;
                if (v < 1 || v > N)
                    throw new ArgumentException($"Valor no válido en la fila {f + 1}, columna {c + 1}.");

                t[f, c] = 0;                       // se quita para no compararlo consigo mismo
                bool valido = EsValido(t, f, c, v);
                t[f, c] = v;

                if (!valido)
                    throw new ArgumentException(
                        $"El número {v} de la fila {f + 1}, columna {c + 1} se repite en su fila, columna o cuadro.");
            }
    }

    /// <summary>Convierte un texto de 81 caracteres (dígitos; 0 o '.' = vacío) en tablero.</summary>
    public static int[,] Parsear(string texto)
    {
        if (texto is null || texto.Length != N * N)
            throw new ArgumentException("El tablero debe tener exactamente 81 caracteres.");

        var t = new int[N, N];
        for (int i = 0; i < texto.Length; i++)
        {
            char ch = texto[i];
            t[i / N, i % N] = ch switch
            {
                >= '1' and <= '9' => ch - '0',
                '0' or '.' => 0,
                _ => throw new ArgumentException($"Carácter no válido en la posición {i + 1}: '{ch}'.")
            };
        }
        return t;
    }

    public static int[,] Clonar(int[,] t) => (int[,])t.Clone();

    public static int ContarVacias(int[,] t)
    {
        int vacias = 0;
        foreach (int v in t)
            if (v == 0)
                vacias++;

        return vacias;
    }

    public static string Nombre(Estrategia e) =>
        e == Estrategia.Secuencial ? "Secuencial" : "Menos candidatos (MRV)";
}