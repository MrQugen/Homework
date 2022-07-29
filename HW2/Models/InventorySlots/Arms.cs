namespace HW2.Models.InventorySlots;

public class Arms
{
    public WeaponCollection Weapon { get; set; } = new WeaponCollection(4);
}