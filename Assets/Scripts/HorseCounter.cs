using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseCounter : MonoBehaviour
{
    public static HorseCounter instance;
    [SerializeField] private int horseAmount;
    [SerializeField] private int amountToCollect;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private string achievementID = "ACH_FIND_ALL_HORSES";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }
    }
    public void HorseCollected()
    {
        horseAmount++;
        if (horseAmount >= amountToCollect)
        {
            victoryScreen.SetActive(true);
            UnlockAchievement();
        }
    }
    public void UnlockAchievement()
    {
        var ach = new Steamworks.Data.Achievement(achievementID);
        ach.Trigger();

        Debug.Log($"Achievement {achievementID} unlocked!");
    }

    public void CheckAchievementStatus()
    {
        var ach = new Steamworks.Data.Achievement(achievementID);

        Debug.Log($"Achievement {achievementID} status: {ach.State}");
    }
    public void RemoveAchievement()
    {
        var ach = new Steamworks.Data.Achievement(achievementID);
        ach.Clear();

        Debug.Log($"Achievement {achievementID} cleared from account.");
    }
}
