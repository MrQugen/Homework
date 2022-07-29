namespace HW2.Models.Items.Base;

public abstract class Armor : Item
{
    private double armour;
    public double Armour
    {
        get => armour;
        set
        {
            if (IsValid(value, nameof(Armor), 1, 55))
            {
                armour = value;
            }
        }
    }

    public Armor(string name, double weight, double armour)
        : base(name, weight)
    {
        Armour = armour;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nArmour:\t{Armour}";
    }
}