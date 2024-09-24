using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Inventory mainInventory;
    public Inventory stablesInventory;
    //public Inventory decorInventory;
    public EquipmentSystem equipSystem;
    public CraftSystem craftSystem;
    public Tooltip tooltip;
    public GameObject draggedItemBox;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning($"Multiple instances of {this.GetType().Name} found! Deleting extra.");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
