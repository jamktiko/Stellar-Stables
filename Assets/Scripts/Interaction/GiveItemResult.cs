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
        inv.addItemToInventory(itemID, itemValue);
    }

    public void SetVariablesThroughEditor(int item, int value)
    {
        itemID = item;
        itemValue = value;
    }
}
