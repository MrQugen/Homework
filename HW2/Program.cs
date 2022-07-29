using HW2.Models;
using HW2.Models.InventorySlots;
using HW2.Models.Items;
using HW2.Models.Items.Quivers;

namespace HW2;

public static class Program
{
    public static void Main(string[] args)
    {
        // Create players who will fight
        var player1 = new Player("Hugh");
        var player2 = new Player("Price");
        
        // If the player has less than 15 health, then he will regenerate 5 units every turn
        player2.AttackOver += (sender, e) =>
        { 
            if (sender is Player {Health: < 15} player)
            {
                player.Health += 5;
                Console.WriteLine($"{player.Name} regained health by 5 units");
            }
        };

        // The first player will have a bow with arrows, a one-handed sword and a shield
        player1.Inventory.Arms.Weapon[WeaponSlot.First] = new Shield("Knightly Heater Shield", 2.5, 5, 80, 90);
        player1.Inventory.Arms.Weapon[WeaponSlot.Second] = new OneHanded("Heavy Sabre", 1.8, 15, 85);
        player1.Inventory.Arms.Weapon[WeaponSlot.Third] = new Crossbow("Siege Crossbow", 3.8, 25, 70, new BoltQuiver("Steel Bolts", 2.5, 25, 8) );
        // Let's leave the last weapon slot empty and check what happens if we try to attack with weapons (fists) from this slot
        
        // The second player will have throwing knives, a two-handed ax, a one-handed mace, and throwing knives
        player2.Inventory.Arms.Weapon[WeaponSlot.First] = new TwoHanded("Two Handed War Axe", 3.5, 25, 60);
        player2.Inventory.Arms.Weapon[WeaponSlot.Second] = new Throwing("Throwing Daggers", 3.5, 10, 90, 10);
        player2.Inventory.Arms.Weapon[WeaponSlot.Third] = new OneHanded("Knobbed Mace", 2.5, 10, 70);
        player2.Inventory.Arms.Weapon[WeaponSlot.Fourth] = new Bow("Strong Bow", 1.5, 15, 80, new ArrowQuiver("Bodkin Arrows", 3, 25, 7));

        // Outfit for first player
        player1.Inventory.Outfit.Helmet = new Helmet("Guard Helmet", 2.5, 55);
        player1.Inventory.Outfit.Body = new Body("Heraldic Mail with Tabard", 21, 55);
        player1.Inventory.Outfit.Boots = new Boots("Splinted Leather Greaves", 2, 40);
        player1.Inventory.Outfit.Gloves = new Gloves("Scale Gauntlets", 0.5, 6);
        
        // Outfit for second player
        player2.Inventory.Outfit.Helmet = new Helmet("Helmet with Cap", 2, 30);
        player2.Inventory.Outfit.Body = new Body("Lamellar Vest", 18, 40);
        player2.Inventory.Outfit.Boots = new Boots("Plated Boots", 3, 15);
        player2.Inventory.Outfit.Gloves = new Gloves("Leather Gloves", 0.25, 2);
        
        // Info about players
        Console.WriteLine(player1);
        Console.WriteLine(player2);
        
        // Let's make a semblance of a battle in turns and after each move we will show the amount of HP each player has
        for (int i = 1; player1.Health != 0 && player2.Health != 0; i++)
        {
            Console.WriteLine($"Turn № {i}:");
            Console.WriteLine($"{player1.Name} health: {player1.Health}");
            Console.WriteLine($"{player2.Name} health: {player2.Health}");
            
            // We choose a random weapon from the slots for each player
            if (i % 2 == 0)
            {
                var weapon = (WeaponSlot)new Random().Next(0, player1.Inventory.Arms.Weapon.Length);
                Console.WriteLine($"{player1.Name} attacks {player2.Name} with weapon {player1.Inventory.Arms.Weapon[weapon]?.Name ?? "Fists"}");
                player1.Attack(player2, weapon);
            }
            else
            {
                var weapon = (WeaponSlot)new Random().Next(0, player2.Inventory.Arms.Weapon.Length);
                Console.WriteLine($"{player2.Name} attacks {player1.Name} with weapon {player2.Inventory.Arms.Weapon[weapon]?.Name ?? "Fists"}");
                player2.Attack(player1, weapon);
            }
            Console.WriteLine();
        }
    }
}