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
            IProblem problem = new Problem40();
            var watch = new Stopwatch();
            watch.Start();
            problem.run();
            watch.Stop();
            Console.WriteLine("Time Elapsed: " + watch.Elapsed);
            Console.ReadLine();
        }

    }
}