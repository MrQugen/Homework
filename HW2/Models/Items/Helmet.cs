using HW2.Models.Items.Base;

namespace HW2.Models.Items;

public class Helmet : Armor
{
    public Helmet(string name, double weight, double armour)
        : base(name, weight, armour)
    {
        
    }
}