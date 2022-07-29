namespace HW2.Models.Items.Base;

public abstract class Item
{
    private string name;
    public string Name
    {
        get => name;
        set
        {
            if (value == "")
            {
                throw new ArgumentException("Name cannot be empty!", nameof(Name));
            }
            name = value;
        }
    }
    
    private double weight;
    public double Weight
    {
        get => weight;
        set
        {
            if (IsValid(value, nameof(Weight), 0.25, 25))
            {
                weight = value;
            }
        }
    }

    public Item(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
    
    protected static bool IsValid(double value, string parameterName, double minValue, double maxValue)
    {
        if (value < 0 || value > maxValue)
        {
            throw new ArgumentException($"Parameter cannot be less than {minValue} or more than a {maxValue}!", parameterName);
        }

        return true;
    }
    public override string ToString()
    {
        return $"Name:\t{Name}\n" +
               $"Weight:\t{Weight}";
    }
}