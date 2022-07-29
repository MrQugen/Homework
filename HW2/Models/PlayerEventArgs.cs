using HW2.Models.InventorySlots;

namespace HW2.Models;

public class PlayerEventArgs : EventArgs
{
    public Player Enemy { get; set; }
    public WeaponSlot WeaponSlot { get; set; }

    public PlayerEventArgs(Player enemy, WeaponSlot weaponSlot)
    {
        Enemy = enemy;
        WeaponSlot = weaponSlot;
    }
}