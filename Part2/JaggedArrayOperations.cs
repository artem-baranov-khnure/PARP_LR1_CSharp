using System.Numerics;

namespace PARP_LR1_CSharp.Part2;

public static class JaggedArrayOperations
{
    public static T[][] Multiply<T>(T[][] a, T[][] b, int n) where T : INumber<T>
    {
        T[][] result = Create<T>(n);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                T sum = T.Zero;
                for (int k = 0; k < n; k++)
                {
                    sum += a[i][k] * b[k][j];
                }
                result[i][j] = sum;
            }
        }
        return result;
    }

    public static T[][] CreateRandom<T>(int n, int seed) where T : INumber<T>
    {
        T[][] values = Create<T>(n);
        var random = new Random(seed);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                values[i][j] = T.CreateTruncating(random.NextDouble() * 9.0);
            }
        }
        return values;
    }

    private static T[][] Create<T>(int n)
    {
        var arr = new T[n][];
        for (int i = 0; i < n; i++)
        {
            arr[i] = new T[n];
        }
        return arr;
    }
}