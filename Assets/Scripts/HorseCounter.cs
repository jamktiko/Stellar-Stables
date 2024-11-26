using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseCounter : MonoBehaviour
{
    public static HorseCounter instance;
    [SerializeField] private int horseAmount;
    [SerializeField] private int amountToCollect;
    [SerializeField] private GameObject victoryScreen;
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
        }
    }
}
