using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SlotData : MonoBehaviour
{

    [SerializeField] private ItemDatabaseObject horseDatabase;
    [SerializeField] private InventoryObject stablesInventory;

    [SerializeField] private ItemObject[] stableSlotItems = new ItemObject[14];

    private UnityEngine.UI.Image[] foodImageObjects = new UnityEngine.UI.Image[14];
    private TextMeshProUGUI[] foodNumberObjects = new TextMeshProUGUI[14];
    private GameObject[] foodDisplayObjects = new GameObject[14];

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
        //Debug.Log("Updated slot data on scene change.");
        if (SceneManager.GetActiveScene().name == "Stables")
        {
            SetFoodSlotObjects();
            UpdateSlotData(); 
        }

        if (FoodInventoryManager.Instance != null)
        {
            FoodInventoryManager.Instance.OnFoodInventoryChanged.AddListener(UpdateFoodIcons);
        }

    }

    private void OnDisable()
    {
        if (FoodInventoryManager.Instance != null)
        {
            FoodInventoryManager.Instance.OnFoodInventoryChanged.RemoveListener(UpdateFoodIcons);
        }
    }

    private void SetFoodSlotObjects()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            foodDisplayObjects[i] = transform.GetChild(i).Find("FoodDisplay").gameObject;
            foodImageObjects[i] = foodDisplayObjects[i].GetComponentInChildren<UnityEngine.UI.Image>();
            foodNumberObjects[i] = foodDisplayObjects[i].GetComponentInChildren<TextMeshProUGUI>();
        }

    }
    public void UpdateFoodIcons()
    {

        for (int i = 0; i < foodImageObjects.Length; i++)
        {
            ItemObject tempSlotData = GetSlotData(i);
            if (tempSlotData == null) 
            {
                foodImageObjects[i].sprite = null;
                foodNumberObjects[i].text = "0";
                foodDisplayObjects[i].GetComponentInChildren<FoodTypeReference>().FoodTypeRef = null;
                foodDisplayObjects[i].SetActive(false);
            }
            else
            {
                foodDisplayObjects[i].SetActive(true);
                foodDisplayObjects[i].GetComponentInChildren<FoodTypeReference>().FoodTypeRef = tempSlotData.data.horseFoodPreference;
                foodImageObjects[i].sprite = tempSlotData.data.horseFoodPreference.foodSprite;
                int foodNumberToSet = FoodInventoryManager.Instance.GetFoodAmount(tempSlotData.data.horseFoodPreference);
                foodNumberObjects[i].text = foodNumberToSet > 99 ? "99+" : foodNumberToSet.ToString();
            }
        }

    }

}
