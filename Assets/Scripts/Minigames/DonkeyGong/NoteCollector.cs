using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollector : MonoBehaviour
{
    [SerializeField] private FoodTypeSO foodSO;

    private void OnMouseDown()
    {
        CollectNote();
    }

    private void CollectNote()
    {
        MinigameScore.Instance.AddScore();
        Debug.Log("Note collected");
        if (FoodInventoryManager.Instance != null)
        {
            FoodInventoryManager.Instance.AddFood(foodSO, 1);
        }
        Destroy(gameObject);
    }

}
