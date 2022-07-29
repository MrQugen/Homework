namespace HW1.Sequences;

public static class Fibonacci
{
    public static IEnumerable<int> Calculate(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number cannot be negative");
        }

        var list = new List<int>();
        Enumerable.Range(0, number).ToList().ForEach(f => list.Add((f <= 1 ? 1 : list[f - 2] + list[f - 1])));
           
        return list;
    }
}