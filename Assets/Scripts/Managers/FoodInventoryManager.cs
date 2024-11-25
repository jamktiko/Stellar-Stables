using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodInventoryManager : MonoBehaviour
{
    public static FoodInventoryManager Instance { get; private set; }

    [SerializeField] private int foodHappinessModifier = 1;

    public UnityEvent OnFoodInventoryChanged = new UnityEvent();

    private Dictionary<FoodTypeSO, int> foodInventory = new Dictionary<FoodTypeSO, int>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
    public void AddFood(FoodTypeSO foodType, int amount)
    {
        if (!foodInventory.ContainsKey(foodType))
        {
            foodInventory[foodType] = 0;
        }
        foodInventory[foodType] += amount;
        UpdateFoodInventoryStats();
    }
    public void RemoveFood(FoodTypeSO foodType, int amount)
    {
        if (foodInventory.ContainsKey(foodType))
        {
            if (foodInventory[foodType] > 0)
            {
                foodInventory[foodType] = Mathf.Max(0, foodInventory[foodType] - amount);
                StableHappinessManager.Instance.IncreaseHappiness(foodHappinessModifier);
                UpdateFoodInventoryStats();
            }

        }
    }

    private void Start()
    {

    }

    private void UpdateFoodInventoryStats()
    {
        OnFoodInventoryChanged.Invoke();
    }

    public int GetFoodAmount(FoodTypeSO foodType)
    {
        return foodInventory.ContainsKey(foodType) ? foodInventory[foodType] : 0;
    }

}
