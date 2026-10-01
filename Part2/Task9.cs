using PARP_LR1_CSharp;
using System.Numerics;

namespace PARP_LR1_CSharp.Part2;

public static class Task9
{
    private const int LabelWidth = 16;

    public static void Run(int n, int repeats)
    {
        Console.WriteLine("Task 9 -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        TablePrinter.PrintHeader("Type", LabelWidth);

        PrintType<sbyte>("sbyte (int8_t)", n, repeats);
        PrintType<short>("short (int16_t)", n, repeats);
        PrintType<int>("int (int32_t)", n, repeats);
        PrintType<long>("long (int64_t)", n, repeats);
        PrintType<float>("float", n, repeats);
        PrintType<double>("double", n, repeats);

        TablePrinter.PrintSeparator(LabelWidth);
    }

    private static void PrintType<T>(string typeName, int n, int repeats) where T : INumber<T>
    {
        TablePrinter.PrintRow(typeName, LabelWidth, ArrayVsObjectBenchmark.Compare<T>(n, repeats));
    }
}