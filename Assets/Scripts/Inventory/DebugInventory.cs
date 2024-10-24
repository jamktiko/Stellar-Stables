using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DebugInventory : MonoBehaviour
{
    [SerializeField] private InventoryObject inventorySO;
    [HideInInspector] public UserInterface userInterface;
    public ItemObject itemSO;
    private Item item;
    public int value;

    private void Start()
    {
        FindInterface();
    }
    public void FindInterface()
    {
        if (inventorySO.name == "Player Inventory")
        {
            userInterface = StaticInterface.instance;
        }
        else if (inventorySO.name == "Stables Inventory")
        {
            userInterface = DynamicInterface.instance;
        }
        else
        {
            Debug.LogWarning("DebugInventory couldn't find an interface. Assign an Inventory Scriptable Object or check if that inventory (tagged) is in the scene.");
        }
    }
    public void AddItemToInventory()
    {
        item = itemSO.CreateItem();
        inventorySO.AddItem(item, value);
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
