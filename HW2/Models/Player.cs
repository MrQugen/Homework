using HW2.Models.InventorySlots;
using HW2.Models.Items;
using HW2.Models.Items.Base;

namespace HW2.Models;

public class Player
{
    private string name;
    public string Name
    {
        get => name;
        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty!", nameof(Name));
            }
            name = value;
        }
    }

    public bool IsAlive => Health > 0;
    
    public Inventory Inventory { get; set; } = new Inventory();

    private bool IsHasShield => Inventory.Arms.Weapon.OfType<Shield>().Any();

    private int health;
    public int Health
    {
        get => health;
        set
        {
            if (IsValid(value, nameof(Health), 0, 100))
            {
                health = value;
                if (value == 0)
                {
                    Console.WriteLine($"{Name} is dead!");
                }
            }
        }
    }

    public double Encumbrance
    {
        get
        {
            double weight = 0;
            foreach (var obj in Inventory.Arms.Weapon)
            {
                if (obj is Weapon weapon)
                {
                    weight += weapon.Weight;
                }
            }

            return weight;
        }
    }

    private int strength;
    public int Strength
    {
        get => strength;
        set
        {
            if (IsValid(value, nameof(Strength), 0, 30))
            {
                strength = value;
            }
        }
    }
    
    private int intelligence;
    public int Intelligence
    {
        get => intelligence;
        set
        {
            if (IsValid(value, nameof(Intelligence), 0, 30))
            {
                intelligence = value;
            }
        }
    }
    
    private int agility;
    public int Agility
    {
        get => agility;
        set
        {
            if (IsValid(value, nameof(Agility), 0, 30))
            {
                agility = value;
            }
        }
    }
    
    public double Armor =>
        Inventory.Outfit.Helmet?.Armour ?? 0 +
        Inventory.Outfit.Body?.Armour ?? 0 +
        Inventory.Outfit.Boots?.Armour ?? 0 +
        Inventory.Outfit.Gloves?.Armour ?? 0;
    
    public event PlayerEventHandler AttackOver = delegate {  };

    public Player(string name)
    {
        var random = new Random();
        Name = name;
        Health = 100;
        Intelligence = random.Next(5, 11);
        Agility = random.Next(5, 11);
        Strength = random.Next(5, 11);
    }

    public void Attack(Player enemy, WeaponSlot weaponSlot)
    {
        if (!IsAlive)
        {
            throw new Exception("One of the players is already dead!");
        }

        int damage = (int)((Strength + Encumbrance / 8) / 2)  + (int)((Agility - Encumbrance / 8) / 2) + Intelligence / 3 +
            (Inventory.Arms.Weapon[weaponSlot]?.MakeDamage() ?? 0) + (int)(enemy.Armor / 4);

        if (enemy.IsHasShield)
        {
            var random = new Random().Next(1, 51);
            if((enemy.Agility - enemy.Encumbrance / 8) * 100 / 30 < random)
            {
                damage = 0;
                Console.WriteLine("Kick blocked!");
            }
        }
        
        OnAttackOver(new PlayerEventArgs(enemy, weaponSlot));
        if (enemy.Health - damage >= 0)
        {
            enemy.Health -= damage;
        }
        else
        {
            enemy.Health = 0;
            Console.WriteLine($"The {Name} killed the {enemy.Name} with a weapon {Inventory.Arms.Weapon[weaponSlot]?.Name ?? "Fists"}");
        }
    }

    private static bool IsValid(double value, string parameterName, double minValue, double maxValue)
    {
        if (value < 0 || value > maxValue)
        {
            throw new ArgumentException($"Parameter cannot be less than {minValue} or more than a {maxValue}!", parameterName);
        }

        return true;
    }

    public override string ToString()
    {
        return $"Name: {Name}\tHealth: {Health}\tArmor: {Armor}\tEncumbrance: {Encumbrance}\n" +
               $"Strength: {Strength}\tIntelligence: {Intelligence}\tAgility:{Agility}\n" +
               "Inventory:\n" +
               "\tOutfit:\n" +
               $"Helmet:\n{Inventory.Outfit.Helmet?.ToString() ?? "-"}\n" +
               $"Body:\n{Inventory.Outfit.Body?.ToString() ?? "-"}\n" +
               $"Boots:\n{Inventory.Outfit.Boots?.ToString() ?? "-"}\n" +
               $"Gloves:\n{Inventory.Outfit.Gloves?.ToString() ?? "-"}\n" +
               "\tArms:\n" +
               $"First:\n{Inventory.Arms.Weapon[WeaponSlot.First]?.ToString() ?? "-"}\n" +
               $"Second:\n{Inventory.Arms.Weapon[WeaponSlot.Second]?.ToString() ?? "-"}\n" +
               $"Third:\n{Inventory.Arms.Weapon[WeaponSlot.Third]?.ToString() ?? "-"}\n" +
               $"Fourth:\n{Inventory.Arms.Weapon[WeaponSlot.Fourth]?.ToString() ?? "-"}\n";
    }
    
    protected virtual void OnAttackOver(PlayerEventArgs e)
    {
        Volatile.Read(ref AttackOver).Invoke(this, e);
    }
}