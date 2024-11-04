using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotData : MonoBehaviour
{

    [SerializeField] private ItemDatabaseObject horseDatabase;
    [SerializeField] private InventoryObject stablesInventory;

    [SerializeField] private ItemObject[] stableSlotItems = new ItemObject[14];

    public void UpdateSlotData()
    {

        for (int i = 0; i < stableSlotItems.Length; i++)
        {
            
            if (stablesInventory.Container.Items[i].item.Id == -1)
            {
                stableSlotItems[i] = null;
            }
            else
            {
                stableSlotItems[i] = horseDatabase.Items[stablesInventory.Container.Items[i].item.Id];
            }
        }

    }

    public ItemObject GetSlotData(int slotId)
    {
        return stableSlotItems[slotId];
    }
    private void OnEnable()
    {
        Debug.Log("Updated slot data on scene change.");
        UpdateSlotData();
    }

}
