using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageItems : MonoBehaviour
{
    public UserInterface userInterface;
    public InventorySlot slot;
    public ItemObject itemSO;
    private Item item;
    public int value;
    public void AddItemToInventory()
    {
        item = item ?? itemSO.CreateItem();
        userInterface.inventory.AddItem(item, value);
        userInterface.RunUpdateSlotDisplay();
    }

    public void RemoveItemFromInventory()
    {
        //needs to know the slot
        slot.RemoveItem();
        userInterface.RunUpdateSlotDisplay();
    }
}
