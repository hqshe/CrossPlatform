namespace Lab2
{
    public class Program
    {
        public static void Main()
        {
            int pos;
            if (!int.TryParse(Console.ReadLine(), out pos))
            {
                throw new Exception("Invalid input");
            }

            for (int step = 26; step >= 1; step--)
            {
                int half = (1 << (step - 1)) - 1;
                if (pos == 1)
                {
                    Console.WriteLine((char)('a' + step - 1));
                    return;
                }
                else if (pos <= 1 + half)
                {
                    pos--;
                }
                else
                {
                    pos -= 1 + half;
                }
            }

            throw new Exception("Should not reach here");
        }
    }
}
