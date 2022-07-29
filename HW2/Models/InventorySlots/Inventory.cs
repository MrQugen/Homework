namespace HW2.Models.InventorySlots;

public class Inventory
{
    public Outfit Outfit { get; set; } = new Outfit();
    public Arms Arms { get; set; } = new Arms();
}