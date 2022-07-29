namespace HW1.Sequences;

public static class Factorial
{
    public static int Calculate(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number cannot be negative");
        }
        
        return Enumerable.Range(1, number).Aggregate(1, (f, i) => f * i);
    }
}