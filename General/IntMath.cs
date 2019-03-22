using System;

namespace General
{
    public static class IntMath
    {
        public static int IntGCF(int a, int b)
        {
            if (a < 0 && b < 0)
                return -GCF(-a, -b);

            return GCF(Math.Abs(a), Math.Abs(b));
        }

        public static int GCF(int a, int b)
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
