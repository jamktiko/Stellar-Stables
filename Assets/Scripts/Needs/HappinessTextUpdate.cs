using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HappinessTextUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI happinessText;
    [SerializeField] private Image barImage;

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
        happinessText.text = "Happiness:    " + StableHappinessManager.Instance.GetHappiness() + "%";
        float happiness = StableHappinessManager.Instance.GetHappiness() / 100f;
        barImage.fillAmount = happiness;
    }

}
