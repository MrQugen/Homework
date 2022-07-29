using HW2.Models.Items.Base;

namespace HW2.Models.Items;

public class Shield : Weapon
{
    private int size;
    public int Size
    {
        get => size;
        set
        {
            if (IsValid(value, nameof(Size), 60, 100))
            {
                size = value;
            }
        }
    }
    
    public Shield(string name, double weigth, int damage, int size, int speed)
        : base(name, weigth, damage, speed)
    {
        Size = size;
    }

    public override int MakeDamage()
    {
        return (int)(Size / 15 * Speed / 10 * Weight / 15);
    }
    
    public override string ToString()
    {
        return base.ToString() +
               $"\nSize:\t{Size}";
    }
}