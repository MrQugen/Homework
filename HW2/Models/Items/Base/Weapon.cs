namespace HW2.Models.Items.Base;

public abstract class Weapon : Item, IWeapon
{
    private int speed;
    public int Speed
    {
        get => speed;
        set
        {
            if (IsValid(value, nameof(Speed), 60, 100))
            {
                speed = value;
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
    
    public Weapon(string name, double weight, int damage, int speed) : base(name, weight)
    {
        Damage = damage;
        Speed = speed;
    }

    public abstract int MakeDamage();
    
    public override string ToString()
    {
        return base.ToString() +
               $"\nDamage:\t{Damage}\n" +
               $"Speed:\t{Speed}";
    }
}