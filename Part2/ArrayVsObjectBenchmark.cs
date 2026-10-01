using System.Numerics;

namespace PARP_LR1_CSharp.Part2;

public static class ArrayVsObjectBenchmark
{
    public static ComparisonResult Compare<T>(int n, int repeats) where T : INumber<T>
    {
        T[][] a = JaggedArrayOperations.CreateRandom<T>(n, 1);
        T[][] b = JaggedArrayOperations.CreateRandom<T>(n, 2);
        double timeWithoutObjects = TimeMeasurer.MeasureMinTime(
            () => JaggedArrayOperations.Multiply(a, b, n), repeats);

        Matrix<T> matrixA = Matrix<T>.CreateRandom(n, 1);
        Matrix<T> matrixB = Matrix<T>.CreateRandom(n, 2);
        double timeWithObjects = TimeMeasurer.MeasureMinTime(
            () => matrixA.Multiply(matrixB), repeats);

        return new ComparisonResult(timeWithoutObjects, timeWithObjects);
    }
}