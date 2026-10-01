using System.Diagnostics;

namespace PARP_LR1_CSharp.Part2;

public static class TimeMeasurer
{
    public static double MeasureMinTime(Action codeToMeasure, int repeats)
    {
        double minTime = double.MaxValue;

        for (int i = 0; i < repeats; i++)
        {
            long start = Stopwatch.GetTimestamp();
            codeToMeasure();
            double elapsedSeconds = Stopwatch.GetElapsedTime(start).TotalSeconds;

            if (elapsedSeconds < minTime)
            {
                minTime = elapsedSeconds;
            }
        }
        return minTime;
    }
}