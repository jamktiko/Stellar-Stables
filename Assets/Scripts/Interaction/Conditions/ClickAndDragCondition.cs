using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ClickAndDragCondition : DraggingHandler, ICondition
{
    //public UserInterface userInterface;
    [SerializeField] private bool isItemConsumed;
    [SerializeField] private GameObject objectToDragOnto;
    //[SerializeField] private ItemObject itemSO;
    //[SerializeField] private int itemValue;
    //private Item item;
    private bool isConditionMet;
    public void Start()
    {
        InitializeEvents(gameObject, gameObject);
        //item = item ?? itemSO.CreateItem();
    }
    public bool IsConditionMet()
    {
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

        return isConditionMet;
    }
    public override void OnDragStart(GameObject obj, Dictionary<GameObject, InventorySlot> slotsOnInterface = null)
    {
        base.OnDragStart(obj);
        
        //gives a null somewhere 
        Debug.Log("OnDragStart in mine!");
    }
    public override void OnDrag(GameObject obj)
    {
        base.OnDrag(obj);
        //it detects objects it hovers over
        //inteface stays null, slot is just object (only works w those with the pointer events added. aka draggable shit)
        //it can detect itself, exclude it
        Debug.Log($"OnDrag in mine! interface is: {MouseData.interfaceMouseIsOver} slot is: {MouseData.slotHoveredOver}");
    }

    public override void OnDragEnd(GameObject obj)
    {
        base.OnDragEnd(obj);
        GetComponent<RectTransform>().position = Input.mousePosition;
        Debug.Log($"OnDragEnd in mine! interface is: {MouseData.interfaceMouseIsOver} slot is: {MouseData.slotHoveredOver}");

        if (MouseData.slotHoveredOver)
        {
            //InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];
            //if (mouseHoverSlotData.item.Id == item.Id)
            //{
            //    isConditionMet = true;
            //    GetComponent<InteractableObject>().OnClick();
            //}
            if (MouseData.slotHoveredOver.gameObject == objectToDragOnto.gameObject)
            {
                isConditionMet = true;
                GetComponent<InteractableObject>().OnClick();
                if (isItemConsumed)
                {
                    Destroy(this);
                }
            }
        }
    }
}
