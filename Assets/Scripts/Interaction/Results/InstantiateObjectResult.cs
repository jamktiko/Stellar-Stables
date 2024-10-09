using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectResult : MonoBehaviour, IResult
{
    [SerializeField] private GameObject objectToSpawn;
    public void Execute()
    {
        Instantiate(objectToSpawn, Input.mousePosition, Quaternion.identity);
    }
}
