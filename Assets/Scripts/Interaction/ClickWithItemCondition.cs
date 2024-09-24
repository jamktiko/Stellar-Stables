using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickWithItemCondition : MonoBehaviour, ICondition
{
    [SerializeField] private bool isItemConsumed;
    [HideInInspector][SerializeField] private int itemID;
    [HideInInspector] [SerializeField] private int itemValue;

    public bool IsConditionMet()
    {
        InventoryManager.instance.mainInventory.updateItemList();
        List<Item> itemsInInventory = new List<Item>(InventoryManager.instance.mainInventory.ItemsInInventory);

        for (int i = 0; i < itemsInInventory.Count; i++)
        {
            if (itemID == itemsInInventory[i].itemID && itemValue >= itemsInInventory[i].itemValue)
            {
                //InventoryManager.instance.mainInventory.ConsumeItem(itemsInInventory[i]);
                return true;
            }
        }
        return false;
    }
    public void SetVariablesThroughEditor(int item, int value)
    {
        itemID = item;
        itemValue = value;
    }
}
