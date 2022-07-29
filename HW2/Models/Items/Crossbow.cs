using HW2.Models.Items.Base;
using HW2.Models.Items.Quivers;

namespace HW2.Models.Items;

public class Crossbow : Weapon
{
    public BoltQuiver BoltQuiver { get; set; }
    
    public Crossbow(string name, double weigth, int damage, int speed, BoltQuiver boltQuiver)
        : base(name, weigth, damage, speed)
    {
        BoltQuiver = boltQuiver;
    }

    public override int MakeDamage()
    {
        if (BoltQuiver.Count > 0)
        {
            BoltQuiver.Count--;
            Console.WriteLine($"Number of bolts in the quiver: {BoltQuiver.Count}");
            return BoltQuiver.Damage * Speed * Damage / 300;
        }
        else
        {
            Console.WriteLine("The quiver is out of bolts for the crossbow!");
            return 0;
        }
    }
    
    public override string ToString()
    {
        return base.ToString() +
               $"\nBoltQuiver:\n{BoltQuiver}";
    }
}