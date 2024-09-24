using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ConsumeItem : MonoBehaviour //, IPointerDownHandler
{
    public Item item;
    public ItemType[] itemTypeOfSlot;

    void Start()
    {
        item = GetComponent<ItemOnObject>().item;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (this.gameObject.transform.parent.parent.parent.GetComponent<EquipmentSystem>() == null)
        {
            bool gearable = false;
            Inventory inventory = transform.parent.parent.parent.GetComponent<Inventory>();

            if (InventoryManager.instance.equipSystem != null)
                itemTypeOfSlot = InventoryManager.instance.equipSystem.itemTypeOfSlots;

            if (data.button == PointerEventData.InputButton.Right)
            {
                //item from craft system to inventory
                if (transform.parent.GetComponent<CraftResultSlot>() != null)
                {
                    bool check = InventoryManager.instance.mainInventory.checkIfItemAllreadyExist(item.itemID, item.itemValue);

                    if (!check)
                    {
                        InventoryManager.instance.mainInventory.addItemToInventory(item.itemID, item.itemValue);
                        InventoryManager.instance.mainInventory.stackableSettings();
                    }

                    InventoryManager.instance.craftSystem.deleteItems(item);
                    CraftResultSlot result = InventoryManager.instance.craftSystem.transform.GetChild(3).GetComponent<CraftResultSlot>();
                    result.temp = 0;
                    InventoryManager.instance.tooltip.deactivateTooltip();
                    gearable = true;
                    GameObject.FindGameObjectWithTag("MainInventory").GetComponent<Inventory>().updateItemList();
                }
                else
                {
                    bool stop = false;
                    if (InventoryManager.instance.equipSystem != null)
                    {
                        for (int i = 0; i < InventoryManager.instance.equipSystem.slotsInTotal; i++)
                        {
                            if (itemTypeOfSlot[i].Equals(item.itemType))
                            {
                                if (InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i).childCount == 0)
                                {
                                    stop = true;
                                    if (InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i).parent.parent.GetComponent<EquipmentSystem>() != null && this.gameObject.transform.parent.parent.parent.GetComponent<EquipmentSystem>() != null) { }
                                    else
                                        inventory.EquiptItem(item);

                                    this.gameObject.transform.SetParent(InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i));
                                    this.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
                                    InventoryManager.instance.equipSystem.gameObject.GetComponent<Inventory>().updateItemList();
                                    inventory.updateItemList();
                                    gearable = true;
                                    break;
                                }
                            }
                        }

                        if (!stop)
                        {
                            for (int i = 0; i < InventoryManager.instance.equipSystem.slotsInTotal; i++)
                            {
                                if (itemTypeOfSlot[i].Equals(item.itemType))
                                {
                                    if (InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i).childCount != 0)
                                    {
                                        GameObject otherItemFromCharacterSystem = InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i).GetChild(0).gameObject;
                                        Item otherSlotItem = otherItemFromCharacterSystem.GetComponent<ItemOnObject>().item;
                                        if (item.itemType == ItemType.UFPS_Weapon)
                                        {
                                            inventory.UnEquipItem1(otherItemFromCharacterSystem.GetComponent<ItemOnObject>().item);
                                            inventory.EquiptItem(item);
                                        }
                                        else
                                        {
                                            inventory.EquiptItem(item);
                                            if (item.itemType != ItemType.Backpack)
                                                inventory.UnEquipItem1(otherItemFromCharacterSystem.GetComponent<ItemOnObject>().item);
                                        }

                                        gearable = true;
                                        InventoryManager.instance.equipSystem.gameObject.GetComponent<Inventory>().updateItemList();
                                        inventory.OnUpdateItemList();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (!gearable && item.itemType != ItemType.UFPS_Ammo && item.itemType != ItemType.UFPS_Grenade)
                {
                    inventory.ConsumeItem(item);

                    item.itemValue--;
                    if (InventoryManager.instance.tooltip != null)
                    {
                        InventoryManager.instance.tooltip.deactivateTooltip();
                        inventory.deleteItemFromInventory(item);
                    }

                    if (item.itemValue <= 0)
                    {
                        if (InventoryManager.instance.tooltip != null)
                            InventoryManager.instance.tooltip.deactivateTooltip();
                        inventory.deleteItemFromInventory(item);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    public void consumeIt()
    {
        Inventory inventory = transform.parent.parent.parent.GetComponent<Inventory>();

        bool gearable = false;

        if (InventoryManager.instance.equipSystem != null)
            itemTypeOfSlot = InventoryManager.instance.equipSystem.itemTypeOfSlots;

        bool stop = false;
        if (InventoryManager.instance.equipSystem != null)
        {

            for (int i = 0; i < InventoryManager.instance.equipSystem.slotsInTotal; i++)
            {
                if (itemTypeOfSlot[i].Equals(item.itemType))
                {
                    if (InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i).childCount == 0)
                    {
                        stop = true;
                        this.gameObject.transform.SetParent(InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i));
                        this.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        InventoryManager.instance.equipSystem.gameObject.GetComponent<Inventory>().updateItemList();
                        inventory.updateItemList();
                        inventory.EquiptItem(item);
                        gearable = true;
                        break;
                    }
                }
            }

            if (!stop)
            {
                for (int i = 0; i < InventoryManager.instance.equipSystem.slotsInTotal; i++)
                {
                    if (itemTypeOfSlot[i].Equals(item.itemType))
                    {
                        if (InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i).childCount != 0)
                        {
                            GameObject otherItemFromCharacterSystem = InventoryManager.instance.equipSystem.transform.GetChild(1).GetChild(i).GetChild(0).gameObject;
                            Item otherSlotItem = otherItemFromCharacterSystem.GetComponent<ItemOnObject>().item;
                            if (item.itemType == ItemType.UFPS_Weapon)
                            {
                                inventory.UnEquipItem1(otherItemFromCharacterSystem.GetComponent<ItemOnObject>().item);
                                inventory.EquiptItem(item);
                            }
                            else
                            {
                                inventory.EquiptItem(item);
                                if (item.itemType != ItemType.Backpack)
                                    inventory.UnEquipItem1(otherItemFromCharacterSystem.GetComponent<ItemOnObject>().item);
                            }

                            gearable = true;
                            InventoryManager.instance.equipSystem.gameObject.GetComponent<Inventory>().updateItemList();
                            inventory.OnUpdateItemList();
                            break;
                        }
                    }
                }
            }
        }
        if (!gearable && item.itemType != ItemType.UFPS_Ammo && item.itemType != ItemType.UFPS_Grenade)
        {
            inventory.ConsumeItem(item);


            item.itemValue--;
            if (InventoryManager.instance.tooltip != null)
            {
                InventoryManager.instance.tooltip.deactivateTooltip();
                inventory.deleteItemFromInventory(item);
            }
            if (item.itemValue <= 0)
            {
                if (InventoryManager.instance.tooltip != null)
                    InventoryManager.instance.tooltip.deactivateTooltip();
                inventory.deleteItemFromInventory(item);
                Destroy(this.gameObject);
            }

        }
    }
}
