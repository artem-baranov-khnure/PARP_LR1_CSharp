namespace PARP_LR1_CSharp.Part2;

public static class Task7
{
    private const int LabelWidth = 10;

    public static void Run(IReadOnlyList<int> sizes, int repeats)
    {
        Console.WriteLine("Task 7 -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        TablePrinter.PrintHeader("Size", LabelWidth);

        ComparisonResult previous = default;
        int previousN = 0;

        foreach (int n in sizes)
        {
            ComparisonResult r = ArrayVsObjectBenchmark.Compare<double>(n, repeats);
            TablePrinter.PrintRow(n.ToString(), LabelWidth, r);

            if (previousN != 0)
            {
                double sizeRatio = (double)n / previousN;
                Console.WriteLine(
                    $"--- T({n}) / T({previousN}): " +
                    $"without objects = {r.TimeWithoutObjects / previous.TimeWithoutObjects:F3}, " +
                    $"with objects = {r.TimeWithObjects / previous.TimeWithObjects:F3}, " +
                    $"theoretically n^3 = {sizeRatio * sizeRatio * sizeRatio:F3}");
            }

            previous = r;
            previousN = n;
        }
        TablePrinter.PrintSeparator(LabelWidth);
    }
}