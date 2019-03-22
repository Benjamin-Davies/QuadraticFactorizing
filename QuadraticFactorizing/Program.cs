using System;
using General;
using static General.IntMath;

namespace QuadraticFactorizing
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Quadratic Equation factorizer!");
            Console.WriteLine("Press Ctrl-C at any time to exit");
            Console.WriteLine("This application only works with integers");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the values for the equation in the form");
                Console.WriteLine("\tax\u00B2 + bx + c");

                int a = IO.ReadInt("a");
                int b = IO.ReadInt("b");
                int c = IO.ReadInt("c");

                var (ax, ac, bx, bc) = Factorize(a, b, c);

                Console.WriteLine($"({ax}x + {ac})({bx}x + {bc})");
            }
        }

        public static (int, int, int, int) Factorize(int a, int b, int c)
        {
            int outerProduct = a * c;
            int factorSearchBound = (int)Math.Sqrt(Math.Abs(outerProduct));
            int b1 = 0, b2 = 0;

            for (int i = -factorSearchBound; i <= factorSearchBound; i++)
            {
                if (i != 0 && outerProduct % i == 0)
                {
                    int j = outerProduct / i;

                    if (i + j == b)
                    {
                        b1 = i;
                        b2 = j;
                        break;
                    }
                }
            }

            int ax = IntGCF(a, b1);
            int bx = a / ax;
            int bc = b1 / ax;
            int ac = c / bc;

            return (ax, ac, bx, bc);
        }
    }
}
