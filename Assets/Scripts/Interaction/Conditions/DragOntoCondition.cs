using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableObject))]
[RequireComponent(typeof(Draggable))]
public class DragOntoCondition : MonoBehaviour, ICondition
{
    [Header("Pick either a Tag or a specific GameObject as the target. \nYou can leave the other variable blank.")]
    [Space(20)]
    [SerializeField] private bool isThisObjectConsumable;
    [SerializeField] private bool isTargetObjectConsumable;
    [Header("Target is ANY object with this tag (Multi)")]
    public string targetObjectTag;
    [Header("Target is ONLY this object.")]
    public  GameObject objectToDragOnto;

    public bool IsConditionMet()
    {
        if (MouseData.objectHoveredOver != null && (!string.IsNullOrEmpty(targetObjectTag) && MouseData.objectHoveredOver.gameObject.CompareTag(targetObjectTag) || (objectToDragOnto != null && MouseData.objectHoveredOver.gameObject == objectToDragOnto.gameObject)))
        {
            if (isThisObjectConsumable)
            {
                Destroy(this.gameObject);
            }

            if (isTargetObjectConsumable)
            {
                Destroy(MouseData.objectHoveredOver.gameObject);
            }
            return true;
        }
        return false;
    }

    //string gives error if empty
    //get this into Draggable
    //draggable should get all the tagged objects and the object to drag onto and Initialize them
    //it should also tell InteractableObject to check conditions
    //then this checks if it's on top of the right object

    //if this OBJECT is dragged ONTO (end) correct object = success, if wrong object/none = failure (nothing happens)
    //if this OBJECT is dragged OVER (continuous) correct object(s) = success
    //if this OBJECT is dragged AWAY (start?) from correct object(s) = success
    //if this ITEM is dragged ONTO (end) correct object = success, item consumed (optional)/item stays in new world slot (optional), if wrong object/none = failure, return item to inventory
}
