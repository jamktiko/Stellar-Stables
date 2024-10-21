using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableObject))]
[RequireComponent(typeof(Draggable))]
public class DragOntoCondition : DraggingHandler, ICondition
{
    //public UserInterface userInterface;
    [SerializeField] private bool isThisObjectConsumable;
    [SerializeField] private bool isTargetObjectConsumable;
    [SerializeField] private GameObject objectToDragOnto;
    //[SerializeField] private ItemObject itemSO;
    //[SerializeField] private int itemValue;
    //private Item item;
    public void Start()
    {
        InitializeEvents(gameObject, gameObject);
        //item = item ?? itemSO.CreateItem();
    }
    public bool IsConditionMet()
    {
        if (MouseData.slotHoveredOver != null && MouseData.slotHoveredOver.gameObject == objectToDragOnto.gameObject)
        {
            if (isThisObjectConsumable)
            {
                Destroy(this.gameObject);
            }

            if (isTargetObjectConsumable)
            {
                Destroy(MouseData.slotHoveredOver.gameObject);
            }
            return true;
        }
        return false;
    }

    //if this OBJECT is dragged ONTO (end) correct object = success, if wrong object/none = failure (nothing happens)
    //if this OBJECT is dragged OVER (continuous) correct object(s) = success
    //if this OBJECT is dragged AWAY (start?) from correct object(s) = success
    //if this ITEM is dragged ONTO (end) correct object = success, item consumed (optional)/item stays in new world slot (optional), if wrong object/none = failure, return item to inventory

    //for (int i = 0; i < userInterface.inventory.Container.Items.Length; i++)
    //{
    //    if (userInterface.inventory.Container.Items[i].item.Id == item.Id)
    //    {
    //        if (isItemConsumed)
    //        {
    //            userInterface.inventory.Container.Items[i].RemoveItem();
    //        }
    //        return true;
    //    }
    //}
    //return false;


    public override void OnDragEnd(GameObject obj)
    {
        GetComponent<InteractableObject>().OnClick();

            //InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];
            //if (mouseHoverSlotData.item.Id == item.Id)
            //{
            //    isConditionMet = true;
            //    GetComponent<InteractableObject>().OnClick();
            //}
    }
}
