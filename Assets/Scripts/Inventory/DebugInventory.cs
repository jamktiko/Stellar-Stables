using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DebugInventory : MonoBehaviour
{
    public UserInterface userInterface;
    //public GameObject slotObject;
    private InventorySlot slot;
    public ItemObject itemSO;
    private Item item;
    public int value;
    public void AddItemToInventory()
    {
        item = item ?? itemSO.CreateItem();
        userInterface.inventory.AddItem(item, value);
        userInterface.RunUpdateSlotDisplay();
    }

    public void RemoveItemFromInventory(int slotIndex)
    {
        //needs to know the slot

        var slotKeyValuePair = userInterface.slotsOnInterface.ElementAt(slotIndex);

        // Remove the item from that slot
        slotKeyValuePair.Value.RemoveItem();
        userInterface.RunUpdateSlotDisplay();
    }

    public void ClearInventory()
    {
        foreach (var slot in userInterface.slotsOnInterface.Values)
        {
            slot.RemoveItem();
        }
        userInterface.RunUpdateSlotDisplay();
    }
}
