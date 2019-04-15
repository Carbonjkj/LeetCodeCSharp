using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tools
{
    public class General
    {
        public static void PrintOut2DArray<T>(T[,] matrix)
        {
            Console.WriteLine("-----2D Array Output-----");
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($"{matrix[i, j]:###}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
