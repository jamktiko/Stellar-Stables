using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GiveItemResult : MonoBehaviour, IResult
{
    [SerializeField] private Inventory inv;
    [SerializeField] private int itemID;
    [SerializeField] private int itemValue;
    public void Execute()
    {
        if (!inv.characterSystem())
        {
            //ItemDataBaseList inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");                            //loading the itemdatabase
            //string[] items = new string[inventoryItemList.itemList.Count];                                                      //create a string array in length of the itemcount
            //for (int i = 1; i < items.Length; i++)                                                                              //go through the item array
            //{
            //    items[i] = inventoryItemList.itemList[i].itemName;                                                              //and paste all names into the array
            //}

            inv.addItemToInventory(itemID, itemValue);                                                                      //and set the settings for possible stackedItems
            inv.stackableSettings();
            inv.OnUpdateItemList();
        }
    }

    public void SetVariablesThroughEditor(int item, int value)
    {
        itemID = item;
        itemValue = value;

        //inv.addItemToInventory(itemID, itemValue);
    }
}
