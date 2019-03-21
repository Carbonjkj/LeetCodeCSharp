using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tools
{
    public class Prime
    {
        public static List<int> Primes = new List<int>() { 2, 3 };
        public static List<int> GetPrimes(int limit)
        {
            int last = Primes[Primes.Count - 1];
            for (int i = last; i <= limit; i++)
            {
                IsPrime(i);
            }
            return Primes.Where(p => p < limit).ToList();
        }

        public static int NextPrime(int current)
        {
            int last = Primes[Primes.Count - 1];
            if (current >= last)
            {
                bool found = false;
                while (!found)
                {
                    found = IsPrime(++last) && last > current;
                }
                return last;
            }
            return Primes.First(p => p > current);
        }

        public static bool IsPrime(int nr)
        {

            if (nr < 2) return false;
            if (nr < 4) return true;
            int last = Primes[Primes.Count - 1];
            if (last * last < nr) GetPrimes(nr);
            for (int i = 0; Primes[i] * Primes[i] <= nr; i++)
            {
                if (nr % Primes[i] == 0) return false;
            }
            Primes.Add(nr);
            return true;
        }
    }
}
