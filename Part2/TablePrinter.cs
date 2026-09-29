namespace PARP_LR1_CSharp.Part2;

public static class TablePrinter
{
    private const int TimeWidth = 20;

    public static void PrintHeader(string labelTitle, int labelWidth)
    {
        PrintSeparator(labelWidth);
        Console.WriteLine(
            $"{labelTitle.PadRight(labelWidth)}" +
            $"{"без об'єктів (с)",TimeWidth}" +
            $"{"з об'єктами (с)",TimeWidth}");
        PrintSeparator(labelWidth);
    }

    public static void PrintRow(string label, int labelWidth, ComparisonResult r)
    {
        Console.WriteLine(
            $"{label.PadRight(labelWidth)}" +
            $"{r.TimeWithoutObjects,TimeWidth:F6}" +
            $"{r.TimeWithObjects,TimeWidth:F6}");
    }

    public static void PrintSeparator(int labelWidth)
    {
        Console.WriteLine(new string('-', labelWidth + TimeWidth * 2));
    }
}