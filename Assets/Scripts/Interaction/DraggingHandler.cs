using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class DraggingHandler : MonoBehaviour
{
    public Dictionary<GameObject, InventorySlot> slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

    public void InitializeEvents(GameObject thisGO, GameObject draggedObject, Dictionary<GameObject, InventorySlot> slotsOnInterface)
    {
        AddEvent(thisGO, EventTriggerType.PointerEnter, delegate { OnEnterInterface(thisGO); });
        AddEvent(thisGO, EventTriggerType.PointerExit, delegate { OnExitInterface(thisGO); });
        AddEvent(draggedObject, EventTriggerType.PointerEnter, delegate { OnEnter(draggedObject); });
        AddEvent(draggedObject, EventTriggerType.PointerExit, delegate { OnExit(draggedObject); });
        AddEvent(draggedObject, EventTriggerType.BeginDrag, delegate { OnDragStart(draggedObject, slotsOnInterface); });
        AddEvent(draggedObject, EventTriggerType.EndDrag, delegate { OnDragEnd(draggedObject); });
        AddEvent(draggedObject, EventTriggerType.Drag, delegate { OnDrag(draggedObject); });
    }
    public void InitializeEvents(GameObject thisGO, GameObject draggedObject)
    {
        AddEvent(thisGO, EventTriggerType.PointerEnter, delegate { OnEnterInterface(thisGO); });
        AddEvent(thisGO, EventTriggerType.PointerExit, delegate { OnExitInterface(thisGO); });
        AddEvent(draggedObject, EventTriggerType.PointerEnter, delegate { OnEnter(draggedObject); });
        AddEvent(draggedObject, EventTriggerType.PointerExit, delegate { OnExit(draggedObject); });
        AddEvent(draggedObject, EventTriggerType.BeginDrag, delegate { OnDragStart(draggedObject); });
        AddEvent(draggedObject, EventTriggerType.EndDrag, delegate { OnDragEnd(draggedObject); });
        AddEvent(draggedObject, EventTriggerType.Drag, delegate { OnDrag(draggedObject); });
    }
    public void InitializeEvents(GameObject thisGO)
    {
        AddEvent(thisGO, EventTriggerType.PointerEnter, delegate { OnEnter(thisGO); });
        AddEvent(thisGO, EventTriggerType.PointerExit, delegate { OnExit(thisGO); });
    }
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public virtual void OnEnterInterface(GameObject inventoryObject)
    {
        Debug.Log("Entered interface!");
        MouseData.interfaceMouseIsOver = inventoryObject.GetComponent<UserInterface>();
    }
    public virtual void OnExitInterface(GameObject inventoryObject)
    {
        Debug.Log("Exited interface.");
        MouseData.interfaceMouseIsOver = null;
    }
    public virtual void OnEnter(GameObject draggedObject)
    {
        Debug.Log("Entered object!");
        MouseData.slotHoveredOver = draggedObject;
    }
    public virtual void OnExit(GameObject draggedObject)
    {
        Debug.Log("Exited object.");
        MouseData.slotHoveredOver = null;
    }
    public virtual void OnDragStart(GameObject draggedObject, Dictionary<GameObject, InventorySlot> slotsOnInterface = null)
    {
        if (slotsOnInterface != null)
        {
            MouseData.tempItemBeingDragged = CreateTempItem(draggedObject, slotsOnInterface);
        }
        else
        {
            MouseData.tempItemBeingDragged = CreateTempItem(draggedObject);
        }
    }

    public virtual void OnDragEnd(GameObject draggedObject)
    {
        Destroy(MouseData.tempItemBeingDragged);
    }
    public virtual void OnDrag(GameObject draggedObject)
    {
        if (MouseData.tempItemBeingDragged != null)
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
    }
    public GameObject CreateTempItem(GameObject draggedObject, Dictionary<GameObject, InventorySlot> slotsOnInterface)
    {
        GameObject tempItem = null;
        if (slotsOnInterface[draggedObject].item.Id >= 0)
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(50, 50);
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
            img.sprite = slotsOnInterface[draggedObject].ItemObject.uiDisplay;
            img.raycastTarget = false;
        }
        return tempItem;
    }
    public GameObject CreateTempItem(GameObject draggedObject)
    {
        GameObject tempItem = null;

        tempItem = new GameObject();
        var rt = tempItem.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50);
        tempItem.transform.SetParent(transform.parent);
        var img = tempItem.AddComponent<Image>();
        img.sprite = draggedObject.GetComponent<Image>().sprite;
        img.raycastTarget = false;

        return tempItem;
    }
}
