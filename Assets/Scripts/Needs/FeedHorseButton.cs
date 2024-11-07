using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedHorseButton : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeReference] private FoodTypeReference foodTypeReference;

    private void OnEnable()
    {
        button.onClick.AddListener(ConsumeFood);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(ConsumeFood);
    }

    public void ConsumeFood()
    {
        FoodInventoryManager.Instance.RemoveFood(foodTypeReference.FoodTypeRef, 1);
        Debug.Log(foodTypeReference.FoodTypeRef.ToString()+" has been consumed.");
    }

}
