using System;
using System.Diagnostics;
using System.Threading;

namespace PARP_LR1_CSharp
{
    internal static class Program
    {
        static void ArrayGenerator(int[] arr, int size)
        {
            // https://learn.microsoft.com/ru-ru/dotnet/api/system.random?view=net-10.0
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(100);
            }
        }

        static void AddValueToArray(int[] arr, int size, int value)
        {
            for (int i = 0; i < size; i++)
            {
                // https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.volatile.read?view=net-10.0
                int current = Volatile.Read(ref arr[i]);
                Volatile.Write(ref arr[i], current + value);
            }
        }

        static double TimeCall(Action action)
        {
            // https://learn.microsoft.com/ru-ru/dotnet/api/system.diagnostics.stopwatch.gettimestamp?view=net-10.0
            long start = Stopwatch.GetTimestamp();
            action();
            long end = Stopwatch.GetTimestamp();
            return (double)(end - start) / Stopwatch.Frequency;
        }

        static void Main()
        {
            Console.WriteLine("Task 4 -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

            int[] arr_sizes = { 100000, 200000, 300000 };
            double[] absolute_time = new double[3];
            long[] relative_count = new long[3];

            for (int i = 0; i < 3; i++)
            {
                int[] arr = new int[arr_sizes[i]];
                ArrayGenerator(arr, arr_sizes[i]);

                const int repeat_count = 50;
                double min_work_time = 1.0e9;

                for (int r = 0; r < 10; r++)
                {
                    double t = TimeCall(() =>
                    {
                        for (int k = 0; k < repeat_count; k++)
                        {
                            AddValueToArray(arr, arr_sizes[i], 2);
                        }
                    });

                    double single_call_time = t / repeat_count;

                    if (single_call_time < min_work_time)
                    {
                        min_work_time = single_call_time;
                    }
                }
                absolute_time[i] = min_work_time;

                long count = 0;

                // https://learn.microsoft.com/ru-ru/dotnet/api/system.environment.tickcount?view=net-10.0
                int start_tick = Environment.TickCount;
                while (Environment.TickCount - start_tick < 2000)
                {
                    AddValueToArray(arr, arr_sizes[i], 2);
                    count++;
                }

                relative_count[i] = count;

                Console.WriteLine($"Current array size = {arr_sizes[i]}   absolute time = {absolute_time[i]:F9} s   relative count = {count}");
            }

            Console.WriteLine("\nRatios, absolute measurement: ");
            Console.WriteLine($"T(200000)/T(100000) = {(absolute_time[1] / absolute_time[0]):F4}");
            Console.WriteLine($"T(300000)/T(100000) = {(absolute_time[2] / absolute_time[0]):F4}");

            Console.WriteLine("\nRatios, relative measurement: ");
            Console.WriteLine($"T(200000)/T(100000) = {((double)relative_count[0] / relative_count[1]):F4}");
            Console.WriteLine($"T(300000)/T(100000) = {((double)relative_count[0] / relative_count[2]):F4}");


            Console.WriteLine("\n\n\n");
            Console.ReadKey();
        }
    }
}
