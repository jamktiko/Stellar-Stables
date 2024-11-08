using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class InstantiateObjectResult : MonoBehaviour, IResult
{
    [SerializeField] private GameObject objectToSpawn;
    //public void Execute()
    //{
    //    GameObject canvas = GameObject.FindWithTag("Canvas");

    //    GameObject spawnedObject = Instantiate(objectToSpawn);
    //    spawnedObject.transform.SetParent(canvas.transform, false);
    //    spawnedObject.GetComponent<RectTransform>().localPosition = GetMousePositionInCanvasSpace();
    //}

    public Vector2 GetMousePositionInCanvasSpace()
    {
        GameObject canvas = GameObject.FindWithTag("Canvas");

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            Camera.main,
            out Vector2 localPoint
        );
        return localPoint;
    }
    public void Execute()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, Input.mousePosition, Quaternion.identity);

        GameObject canvas = GameObject.FindWithTag("Canvas");
        spawnedObject.transform.SetParent(canvas.transform);
    }
}
