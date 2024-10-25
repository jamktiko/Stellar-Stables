using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventoryManager : MonoBehaviour
{
    public static FoodInventoryManager Instance { get; private set; }

    [SerializeField] private int fishAmount = 0;
    public int FishAmount { 
        get 
        {
            return fishAmount;
        }
        set 
        {
            fishAmount = value;
            UpdateFoodInventoryStats();
        }
    }

    [SerializeField] private int noteAmount;
    public int NoteAmount
    {
        get
        {
            return noteAmount;
        }
        set
        {
            noteAmount = value;
            UpdateFoodInventoryStats();
        }
    }

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
        DontDestroyOnLoad(gameObject);
    }

    private void UpdateFoodInventoryStats()
    {

    }

}
