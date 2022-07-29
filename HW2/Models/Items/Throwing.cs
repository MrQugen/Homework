using HW2.Models.Items.Base;

namespace HW2.Models.Items;

public class Throwing : Weapon
{
    private int count;
    public int Count
    {
        get => count;
        set
        {
            if (IsValid(value, nameof(Damage), 1, 30))
            {
                count = value;
            }
        }
    }

    public Throwing(string name, double weight, int damage, int speed, int count)
        : base(name, weight, damage, speed)
    {
        Count = count;
    }

    public override int MakeDamage()
    {
        if (Count > 0)
        {
            Count--;
            Console.WriteLine($"Number of arrows in the quiver: {Count}");
            return Speed * Damage / 80;
        }
        else
        {
            Console.WriteLine("Thrown weapons out of stock!");
            return 0;
        }
    }
    
    public override string ToString()
    {
        return base.ToString() +
               $"\nCount:\t{Count}";
    }
}