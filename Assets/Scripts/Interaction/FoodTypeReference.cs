using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTypeReference : MonoBehaviour
{
    [SerializeField] private FoodTypeSO _foodTypeRef;
    public FoodTypeSO FoodTypeRef
    {
        get { return _foodTypeRef; }
        set { _foodTypeRef = value; }
    }

}
