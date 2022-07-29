using HW1.Sequences;

namespace HW1;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(Factorial.Calculate(5));
            Console.WriteLine(Factorial.Calculate(1));
            Console.WriteLine(Factorial.Calculate(0));
            Console.WriteLine(Factorial.Calculate(-7));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            foreach (var item in Fibonacci.Calculate(15))
            {
                Console.WriteLine(item);
            }

            foreach (var item in Fibonacci.Calculate(-2))
            {
                Console.WriteLine(item);
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}