using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HappinessTextUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI happinessText;

    private void OnEnable()
    {
        FoodInventoryManager.Instance.OnFoodInventoryChanged.AddListener(UpdateFoodStat);
        StableHappinessManager.Instance.OnHappinessChanged.AddListener(UpdateFoodStat);
        UpdateFoodStat();
    }

    private void OnDisable()
    {
        FoodInventoryManager.Instance.OnFoodInventoryChanged.RemoveListener(UpdateFoodStat);
        StableHappinessManager.Instance.OnHappinessChanged.RemoveListener(UpdateFoodStat);
    }

    private void UpdateFoodStat()
    {
        happinessText.text = "Stables Overall Happiness:    " + StableHappinessManager.Instance.GetHappiness() + "%";
    }

}
