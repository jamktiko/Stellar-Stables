using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ClickAndDragCondition : MonoBehaviour, ICondition
{
    //protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    //{
    //    EventTrigger trigger = obj.GetComponent<EventTrigger>();
    //    var eventTrigger = new EventTrigger.Entry();
    //    eventTrigger.eventID = type;
    //    eventTrigger.callback.AddListener(action);
    //    trigger.triggers.Add(eventTrigger);
    //}

    //public void Start()
    //{
    //    AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
    //    AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
    //    AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
    //    AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
    //    AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
    //}
    public bool IsConditionMet()
    {
        return true;
    }

    void Drag()
    {

        //drag object then if success = consume, if fail = go back to inventory (dragtofeed type shit)
        //AND
        //drag object then if success = stays there, if fail = go back to inventory (equipment system usage)
    }
}
