using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : DraggingHandler
{
    public void Start()
    {
        InitializeEvents(gameObject, gameObject);
    }

    public override void OnDragStart(GameObject obj, Dictionary<GameObject, InventorySlot> slotsOnInterface = null)
    {
        base.OnDragStart(obj);
        //gives a null somewhere?
    }
    public override void OnDrag(GameObject obj)
    {
        //it detects objects it hovers over
        //inteface stays null, slot is just object (only works w those with the pointer events added. aka draggable shit)
        //it can detect itself, exclude it
        base.OnDrag(obj);
    }
    public override void OnDragEnd(GameObject obj)
    {
        base.OnDragEnd(obj);
        GetComponent<RectTransform>().position = Input.mousePosition;
        //Debug.Log($"OnDragEnd in mine! interface is: {MouseData.interfaceMouseIsOver} slot is: {MouseData.slotHoveredOver}");
    }
}
