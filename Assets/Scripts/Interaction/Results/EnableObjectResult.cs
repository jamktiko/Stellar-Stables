using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectResult : MonoBehaviour, IResult
{
    [SerializeField] private GameObject objectToEnable;

    public void Execute()
    {
        objectToEnable.SetActive(!objectToEnable.activeInHierarchy);
    }
}
