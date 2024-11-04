using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SlotData : MonoBehaviour
{

    [SerializeField] private ItemDatabaseObject horseDatabase;
    [SerializeField] private InventoryObject stablesInventory;

    [SerializeField] private ItemObject[] stableSlotItems = new ItemObject[14];

    private UnityEngine.UI.Image[] foodSlotObjects = new UnityEngine.UI.Image[14];

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

        UpdateFoodIcons();

    }
    public ItemObject GetSlotData(int slotId)
    {
        return stableSlotItems[slotId];
    }

    private void OnEnable()
    {
        Debug.Log("Updated slot data on scene change.");
        if (SceneManager.GetActiveScene().name == "Stables")
        {
            SetFoodSlotObjects();
            UpdateSlotData(); 
        }

    }

    private void SetFoodSlotObjects()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            foodSlotObjects[i] = transform.GetChild(i).Find("FoodDisplay").GetComponentInChildren<UnityEngine.UI.Image>();
        }

    }

    public void UpdateFoodIcons()
    {

        for (int i = 0; i < foodSlotObjects.Length; i++)
        {
            ItemObject tempSlotData = GetSlotData(i);
            if (tempSlotData == null) 
            {
                foodSlotObjects[i].sprite = null;
            }
            else
            {
                foodSlotObjects[i].sprite = tempSlotData.data.horseFoodIcon;
            }
        }

    }

}
