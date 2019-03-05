using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp4.ProblemEZ;
using Words = Microsoft.Office.Interop.Word;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new Problem100();
            problem.run();
            Console.ReadLine();
        }

    }
}