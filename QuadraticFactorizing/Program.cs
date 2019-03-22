using System;

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

                int a = ReadInt("a");
                int b = ReadInt("b");
                int c = ReadInt("c");

                var (ax, ac, bx, bc) = Factorize(a, b, c);

                Console.WriteLine($"({ax}x + {ac})({bx}x + {bc})");
            }
        }

        private static int ReadInt(string numName)
        {
            while (true)
            {
                Console.Write($"{numName} = ");
                string s = Console.ReadLine();

                if (int.TryParse(s, out int result))
                {
                    return result;
                }

                Console.WriteLine($"{s} is not a valid integer");
            }
        }

        private static (int, int, int, int) Factorize(int a, int b, int c)
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

        private static int IntGCF(int a, int b)
        {
            if (a < 0 && b < 0)
                return -GCF(-a, -b);

            return GCF(Math.Abs(a), Math.Abs(b));
        }

        private static int GCF(int a, int b)
        {
            int max = Math.Min(a, b);

            for (int i = max; i > 0; i--)
            {
                if (a % i == 0 && b % i == 0)
                {
                    return i;
                }
            }

            return 1;
        }
    }
}
