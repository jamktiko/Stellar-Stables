using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleReducer : MonoBehaviour
{
    [SerializeField] private GameObject objectToReduce;
    public void ReduceScale()
    {
        objectToReduce.transform.localScale *= 0.9f;
    }
}
