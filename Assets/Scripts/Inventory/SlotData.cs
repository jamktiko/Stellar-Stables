using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private HorseAnimationHandler[] horseAnimationHandlers = new HorseAnimationHandler[14];

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

        UpdateIcons();

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
            SetSlotObjects();
            UpdateSlotData(); 
        }

        if (FoodInventoryManager.Instance != null)
        {
            FoodInventoryManager.Instance.OnFoodInventoryChanged.AddListener(UpdateIcons);
        }

    }

    private void OnDisable()
    {
        if (FoodInventoryManager.Instance != null)
        {
            FoodInventoryManager.Instance.OnFoodInventoryChanged.RemoveListener(UpdateIcons);
        }
    }

    private void SetSlotObjects()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            horseAnimationHandlers[i] = transform.GetChild(i).Find("ItemDisplay").gameObject.GetComponentInChildren<HorseAnimationHandler>();
            foodDisplayObjects[i] = transform.GetChild(i).Find("FoodDisplay").gameObject;
            foodImageObjects[i] = foodDisplayObjects[i].GetComponentInChildren<UnityEngine.UI.Image>();
            foodNumberObjects[i] = foodDisplayObjects[i].GetComponentInChildren<TextMeshProUGUI>();
        }

    }
    public void UpdateIcons()
    {

        for (int i = 0; i < foodImageObjects.Length; i++)
        {
            ItemObject tempSlotData = GetSlotData(i);
            if (tempSlotData == null) 
            {
                horseAnimationHandlers[i].Stop();
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
                if (tempSlotData.data.horseAnimation != null)
                {
                    Debug.Log("Horse animation set in stables");
                    horseAnimationHandlers[i].horseAnimation = tempSlotData.data.horseAnimation;
                    horseAnimationHandlers[i].Play(); 
                }
                int foodNumberToSet = FoodInventoryManager.Instance.GetFoodAmount(tempSlotData.data.horseFoodPreference);
                foodNumberObjects[i].text = foodNumberToSet > 99 ? "99+" : foodNumberToSet.ToString();
            }
        }

    }

}
