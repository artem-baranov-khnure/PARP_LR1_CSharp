using System.Numerics;

namespace PARP_LR1_CSharp.Part2;

public class Matrix<T> where T : INumber<T>
{
    private readonly int _size;
    private readonly T[] _data;

    public Matrix(int n)
    {
        _size = n;
        _data = new T[n * n];
    }

    public static Matrix<T> CreateRandom(int n, int seed)
    {
        var matrix = new Matrix<T>(n);
        var random = new Random(seed);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = T.CreateTruncating(random.NextDouble() * 9.0);
            }
        }
        return matrix;
    }

    public T this[int row, int col]
    {
        get => _data[row * _size + col];
        set => _data[row * _size + col] = value;
    }

    public Matrix<T> Multiply(Matrix<T> other)
    {
        var result = new Matrix<T>(_size);

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                T sum = T.Zero;
                for (int k = 0; k < _size; k++)
                {
                    sum += this[i, k] * other[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }
}