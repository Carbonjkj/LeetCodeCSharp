using System;
using System.Diagnostics;
using LeetCode.ProblemEZ;
using LeetCode.ProblemMD;


namespace LeetCode
{
    class Program
    {
        static void Main()
        {
            IProblem problem = new Problem60();
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                problem.run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            watch.Stop();
            Console.WriteLine("Time Elapsed: " + watch.Elapsed);
            Console.ReadLine();
        }

    }
}