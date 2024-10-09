using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectResult : MonoBehaviour, IResult
{
    [SerializeField] private GameObject objectToSpawn;
    public void Execute()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, Input.mousePosition, Quaternion.identity);

        GameObject canvas = GameObject.FindWithTag("Canvas");
        spawnedObject.transform.SetParent(canvas.transform);
    }
}
