using HW2.Models.Items.Base;

namespace HW2.Models.Items.Quivers;

public class BoltQuiver : Item
{
    private int count;
    public int Count
    {
        get => count;
        set
        {
            if (IsValid(value, nameof(Damage), 0, 30))
            {
                count = value;
            }
        }
    }
    
    private int damage;
    public int Damage
    {
        get => damage;
        set
        {
            if (IsValid(value, nameof(Damage), 1, 50))
            {
                damage = value;
            }
        }
    }
    
    public BoltQuiver(string name, double weight, int count, int damage)
        : base(name, weight)
    {
        Count = count;
        Damage = damage;
    }
    
    public override string ToString()
    {
        return base.ToString() +
               $"\nCount:\t{Count}\n" +
               $"Damage:\t{Damage}";
    }
}