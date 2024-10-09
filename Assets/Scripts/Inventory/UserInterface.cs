using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class UserInterface : DraggingHandler
{
    public InventoryObject inventory;
    void Start()
    {
        SetInventoryParent();
        CreateSlots();
    }

    void Update()
    {
        RunUpdateSlotDisplay();
    }

    public void SetInventoryParent()
    {
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            inventory.Container.Items[i].parent = this;
        }
    }

    public void RunUpdateSlotDisplay()
    {
        slotsOnInterface.UpdateSlotDisplay();
    }
    public abstract void CreateSlots();

    public override void OnDragEnd(GameObject obj)
    {
        //obj = last slot the item was in
        base.OnDragEnd(obj);
        if (MouseData.interfaceMouseIsOver == null)
        {
            //when dragged into nothing = delete
            //commenting this out makes it act the same as 2nd part. aka it returns to where it was (cus tempt was deleted)
            //slotsOnInterface[obj].RemoveItem();
            return;
        }
        if (MouseData.slotHoveredOver)
        {
            //when dragged into a slot = move it there
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];
            //slotHoveredOver = slot the mouse was over. aka the new slot
            inventory.SwapItems(slotsOnInterface[obj], mouseHoverSlotData);
        }
    }
}

public static class ExtensionMethods
{
    public static void UpdateSlotDisplay(this Dictionary<GameObject, InventorySlot> _slotsOnInterface)
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in _slotsOnInterface)
        {
            if (_slot.Value.item.Id >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _slot.Value.ItemObject.uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
}