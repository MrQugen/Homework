using HW2.Models.Items.Base;
using HW2.Models.Items.Quivers;

namespace HW2.Models.Items;

public class Bow : Weapon
{
    public ArrowQuiver ArrowQuiver { get; set; }

    public Bow(string name, double weigth, int damage, int speed, ArrowQuiver arrowQuiver) : base(name, weigth, damage, speed)
    {
        ArrowQuiver = arrowQuiver;
    }

    public override int MakeDamage()
    {
        if (ArrowQuiver.Count > 0)
        {
            ArrowQuiver.Count--;
            Console.WriteLine($"Number of arrows in the quiver: {ArrowQuiver.Count}");
            return ArrowQuiver.Damage * Speed * Damage / 350;
        }
        else
        {
            Console.WriteLine("The quiver is out of arrows for the bow!");
            return 0;
        }
    }
    
    public override string ToString()
    {
        return base.ToString() +
               $"\nArrowQuiver:\n{ArrowQuiver}";
    }
}