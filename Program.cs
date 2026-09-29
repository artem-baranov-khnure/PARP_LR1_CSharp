using PARP_LR1_CSharp.Part2;

namespace PARP_LR1_CSharp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Task7.Run(new[] { 512, 1024, 2048 }, repeats: 1);
            Task9.Run(n: 1024, repeats: 1);
        }
    }
}
