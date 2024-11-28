using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StableHappinessManager : MonoBehaviour
{
    public static StableHappinessManager Instance { get; private set; }

    public UnityEvent OnHappinessChanged = new UnityEvent();

    [SerializeField] private InventoryObject stablesInventory;

    [SerializeField] private int stableHappiness = 100;
    [SerializeField] private float cycleLength = 15f;

    public bool IsStablesFilled { get; set; } 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Debug.Log("Hunger Cycle invoked");
        InvokeRepeating("HungerCycle", cycleLength, cycleLength);
    }

    public void IncreaseHappiness(int change)
    {
        
        if (IsStablesFilled)
        {
            stableHappiness = Mathf.Min(110, stableHappiness + change);
            UpdateStats();
        }
    }

    public void DecreaseHappiness(int change)
    {
        
        if (IsStablesFilled)
        {
            stableHappiness = Mathf.Max(0, stableHappiness - change);
            UpdateStats(); 
        }
    }

    public int GetHappiness()
    {
        return stableHappiness;
    }

    private void HungerCycle()
    {
        DecreaseHappiness(1);
    }

    private void UpdateStats()
    {
        OnHappinessChanged.Invoke();
    }

}
