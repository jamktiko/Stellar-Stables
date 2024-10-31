using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventoryManager : MonoBehaviour
{
    public static FoodInventoryManager Instance { get; private set; }

    [SerializeField] private int fishAmount = 0;
    [SerializeField] private int levelIncreaseRequirement;
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

    }

    private void UpdateFoodInventoryStats()
    {
        CheckForDifficultyIncrease();
    }

    private void CheckForDifficultyIncrease()
    {
        //if (fishAmount >= MinigameLevelManager.Instance.FishLevelIndex*levelIncreaseRequirement)
        //{
        //    MinigameLevelManager.Instance.FishLevelIndex++;
        //}
        if (noteAmount >= MinigameLevelManager.Instance.MusicLevelIndex*levelIncreaseRequirement)
        {
            MinigameLevelManager.Instance.MusicLevelIndex++;
        }
    }

}
