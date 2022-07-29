using HW2.Models.Items.Base;

namespace HW2.Models.Items;

public class OneHanded : Weapon
{
    public OneHanded(string name, double weight, int damage, int speed)
        : base(name, weight, damage, speed)
    {
        
    }

    public override int MakeDamage()
    {
        return (int)(Speed * Weight * Damage / 130);
    }
}