using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : DraggingHandler
{
    public void Start()
    {
        InitializeEvents(gameObject, gameObject);
    }
    public override void OnDragEnd(GameObject obj)
    {
        base.OnDragEnd(obj);
        GetComponent<RectTransform>().position = Input.mousePosition;
    }
}
