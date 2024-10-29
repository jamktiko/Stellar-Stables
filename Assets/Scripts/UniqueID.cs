using UnityEngine;
using System;

//[ExecuteAlways]
public class UniqueID : MonoBehaviour
{
    [SerializeField] private string uniqueID;

    //public string ID => uniqueID;

    //private void Awake()
    //{
    //    if (string.IsNullOrEmpty(uniqueID))
    //    {
    //        GenerateID();
    //    }
    //}
    //private void GenerateID()
    //{
    //    uniqueID = Guid.NewGuid().ToString();
    //    Debug.Log($"GUID for {gameObject.name} is: {uniqueID}");
    //}
}

