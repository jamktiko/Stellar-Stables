using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class ToggleObjectResult : MonoBehaviour, IResult
{
    [Header("Set an object to active/disabled in hierarchy.")]
    [SerializeField] private GameObject objectToToggle;

    public void Execute()
    {
        objectToToggle.SetActive(!objectToToggle.activeInHierarchy);
    }
}
