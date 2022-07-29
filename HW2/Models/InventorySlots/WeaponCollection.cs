using System.Collections;
using HW2.Models.Items.Base;

namespace HW2.Models.InventorySlots;

public class WeaponCollection : IEnumerable
{
    private Weapon[] WeaponArr { get; }
    public int Length => WeaponArr.Length;

    public WeaponCollection(int size)
    {
        WeaponArr = new Weapon[size];
    }
    
    public Weapon this[WeaponSlot index]
    {
        get => WeaponArr[(int)index];
        set => WeaponArr[(int)index] = value;
    }

    public IEnumerator GetEnumerator()
    {
        return WeaponArr.GetEnumerator();
    }

}