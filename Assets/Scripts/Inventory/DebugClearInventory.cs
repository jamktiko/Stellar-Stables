using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugClearInventory : MonoBehaviour
{
    [Header("This clears all items from the inventory SOs at Start. \nThen it deletes itself.")]
    [SerializeField] private bool isPlayerCleared = true;
    [SerializeField] private bool isStablesCleared = true;
   // [SerializeField] private bool isInventoryCleared = true;
    private void Start()
    {
        if (isPlayerCleared)
        {
            StaticInterface.instance.ClearInventory();
            //Debug.Log("PlayerInventory cleared");
        }

        if (isStablesCleared)
        {
            DynamicInterface.instance.ClearInventory();
        }

        Destroy(this);
    }
}
