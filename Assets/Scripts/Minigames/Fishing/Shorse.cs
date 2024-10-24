using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shorse : Fish
{
    [Header("This gives an item directly to the Stables' inventory.")]
    [SerializeField] private ItemObject horseSO;
    private InventoryObject inventorySO;
    private Item item;
    override public void Catch()
    {
        Debug.Log("Shorse caught!");
        item = horseSO.CreateItem();
        inventorySO.AddItem(item, 1);
        Destroy(gameObject);
    }
}
