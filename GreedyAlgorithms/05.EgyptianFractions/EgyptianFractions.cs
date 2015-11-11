namespace _05.EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EgyptianFractions
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
            int p = numbers[0];
            int q = numbers[1];

            if (q == 0 || p > q)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
            }

            Fraction fraction = new Fraction(p, q);
            Fraction biggestFraction = new Fraction(1, 2);

            List<Fraction> egyptianFractions = GetEgyptianFractions(fraction, biggestFraction);

            Console.WriteLine(fraction + " = " + string.Join(" + ", egyptianFractions));
        }

        private static List<Fraction> GetEgyptianFractions(Fraction fraction, Fraction biggestFraction)
        {
            List<Fraction> result = new List<Fraction>();

            while (fraction.CompareTo(biggestFraction) != 0)
            {
                if (fraction.CompareTo(biggestFraction) < 0)
                {
                    while (fraction.CompareTo(biggestFraction) < 0)
                    {
                        var newFr = new Fraction(biggestFraction.Nominator, biggestFraction.Denominator + 1);
                        biggestFraction = newFr;
                    }
                }
                else
                {
                    result.Add(biggestFraction);
                    fraction -= biggestFraction;
                }
            }

            result.Add(biggestFraction);
            return result;
        }
    }
}