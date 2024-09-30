using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GiveItemResult : MonoBehaviour, IResult
{
    [HideInInspector] [SerializeField] private int itemID;
    [HideInInspector] [SerializeField] private int itemValue;
    public void Execute()
    {
        InventoryManager.instance.mainInventory.addItemToInventory(itemID, itemValue);
    }
}
