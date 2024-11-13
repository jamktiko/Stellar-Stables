using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectFood : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private FoodTypeSO foodType;
    [SerializeField] private float respwanDelay;

    private bool isEnabled = true;
    private float nextEnableTime;

    private void OnEnable()
    {

    }

    public void OnCollect()
    {
        if (isEnabled)
        {
            FoodInventoryManager.Instance.AddFood(foodType, 1);
            isEnabled = false;
            image.enabled = false;
            button.enabled = false;
            text.enabled = false;

            nextEnableTime = Time.time + respwanDelay;

        }
    }

    private void Update()
    {
        if (Time.time >= nextEnableTime)
        {
            image.enabled = true;
            button.enabled = true;
            text.enabled = true;
            isEnabled = true;
        }
    }

}
