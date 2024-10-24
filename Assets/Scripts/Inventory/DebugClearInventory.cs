using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugClearInventory : MonoBehaviour
{
    [Header("This clears all items from the inventory SOs at Awake. \nThen it deletes itself.")]
    [SerializeField] private bool isPlayerCleared = true;
    [SerializeField] private bool isStablesCleared = true;
    private void Awake()
    {
        if (isPlayerCleared)
        {
            StaticInterface.instance.ClearInventory();
        }

        if (isStablesCleared)
        {
            DynamicInterface.instance.ClearInventory();
        }

        Destroy(this);
    }
}
