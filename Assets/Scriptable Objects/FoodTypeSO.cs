using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodTypeSO", menuName = "ScriptableObjects/FoodTypeScriptableObject", order = 1)]

public class FoodTypeSO : ScriptableObject
{
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private string _foodName;
    
    public string GetFoodName() {  return _foodName; }
    public GameObject GetFoodPrefab() { return _foodPrefab; }

}
