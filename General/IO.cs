using System;
namespace General
{
    public static class IO
    {
        public static int ReadInt(string numName)
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
    }
}
