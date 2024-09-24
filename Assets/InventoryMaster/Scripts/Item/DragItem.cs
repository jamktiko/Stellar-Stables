using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    private Vector2 pointerOffset;
    private RectTransform rectTransform;
    private RectTransform rectTransformSlot;
    private CanvasGroup canvasGroup;
    private GameObject oldSlot;
    private Inventory inventory;

    public delegate void ItemDelegate();
    public static event ItemDelegate updateInventoryList;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransformSlot = InventoryManager.instance.draggedItemBox.GetComponent<RectTransform>();
        inventory = transform.parent.parent.parent.GetComponent<Inventory>();
    }

    public void OnDrag(PointerEventData data)
    {
        if (rectTransform == null)
            return;

        if (data.button == PointerEventData.InputButton.Left && transform.parent.GetComponent<CraftResultSlot>() == null)
        {
            rectTransform.SetAsLastSibling();
            transform.SetParent(InventoryManager.instance.draggedItemBox.transform);
            Vector2 localPointerPosition;
            canvasGroup.blocksRaycasts = false;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransformSlot, Input.mousePosition, data.pressEventCamera, out localPointerPosition))
            {
                rectTransform.localPosition = localPointerPosition - pointerOffset;
            }
        }

        inventory.OnUpdateItemList();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, data.position, data.pressEventCamera, out pointerOffset);
            oldSlot = transform.parent.gameObject;
        }
        if (updateInventoryList != null)
            updateInventoryList();
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            //let go of item where it's at (and make sure it's still useable afterwards)
            canvasGroup.blocksRaycasts = true;
            Transform newSlot = null;
            if (data.pointerEnter != null)
                newSlot = data.pointerEnter.transform;

            if (newSlot != null)
            {
                //getting the items from the slots, GameObjects and RectTransform
                GameObject firstItemGameObject = this.gameObject;
                GameObject secondItemGameObject = newSlot.parent.gameObject;
                RectTransform firstItemRectTransform = this.gameObject.GetComponent<RectTransform>();
                RectTransform secondItemRectTransform = newSlot.parent.GetComponent<RectTransform>();
                Item firstItem = rectTransform.GetComponent<ItemOnObject>().item;
                Item secondItem = new Item();
                if (newSlot.parent.GetComponent<ItemOnObject>() != null)
                    secondItem = newSlot.parent.GetComponent<ItemOnObject>().item;

                //get some informations about the two items
                bool sameItem = firstItem.itemName == secondItem.itemName;
                bool sameItemRerferenced = firstItem.Equals(secondItem);
                bool secondItemStack = false;
                bool firstItemStack = false;
                if (sameItem)
                {
                    firstItemStack = firstItem.itemValue < firstItem.maxStack;
                    secondItemStack = secondItem.itemValue < secondItem.maxStack;
                }

                GameObject Inventory = secondItemRectTransform.parent.gameObject;
                if (Inventory.tag == "Slot")
                    Inventory = secondItemRectTransform.parent.parent.parent.gameObject;

                if (Inventory.tag.Equals("Slot"))
                    Inventory = Inventory.transform.parent.parent.gameObject;

                //dragging in an Inventory      
                DragItemInInventory(newSlot, firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform, firstItem, secondItem, sameItem, sameItemRerferenced, secondItemStack, firstItemStack, Inventory);

                //dragging into an Equipmentsystem
                DragIntoEquipment(newSlot, firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform, firstItem, secondItem, sameItemRerferenced, Inventory);

                //dragging into a CraftingSystem
                DragIntoCrafting(newSlot, firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform, firstItem, secondItem, sameItem, sameItemRerferenced, secondItemStack, firstItemStack, Inventory);

                DragToFeed(firstItemGameObject, firstItemRectTransform, firstItem, secondItem);
            }

            else
            {
                //when dragged into nothing
            }
        }
        inventory.OnUpdateItemList();
    }


    private void DragIntoCrafting(Transform newSlot, GameObject firstItemGameObject, GameObject secondItemGameObject, RectTransform firstItemRectTransform, RectTransform secondItemRectTransform, Item firstItem, Item secondItem, bool sameItem, bool sameItemRerferenced, bool secondItemStack, bool firstItemStack, GameObject Inventory)
    {
        if (Inventory.GetComponent<CraftSystem>() != null)
        {
            CraftSystem cS = Inventory.GetComponent<CraftSystem>();
            int newSlotChildCount = newSlot.transform.parent.childCount;


            bool isOnSlot = newSlot.transform.parent.GetChild(0).tag == "ItemIcon";
            //dragging on a slot where allready is an item on
            if (newSlotChildCount != 0 && isOnSlot)
            {
                //check if the items fits into the other item
                bool fitsIntoStack = false;
                if (sameItem)
                    fitsIntoStack = (firstItem.itemValue + secondItem.itemValue) <= firstItem.maxStack;
                //if the item is stackable checking if the firstitemstack and seconditemstack is not full and check if they are the same items

                if (inventory.stackable && sameItem && firstItemStack && secondItemStack)
                {
                    //if the item does not fit into the other item
                    if (fitsIntoStack && !sameItemRerferenced)
                    {
                        secondItem.itemValue = firstItem.itemValue + secondItem.itemValue;
                        secondItemGameObject.transform.SetParent(newSlot.parent.parent);
                        Destroy(firstItemGameObject);
                        secondItemRectTransform.localPosition = Vector3.zero;

                        cS.ListWithItem();
                    }

                    else
                    {
                        //creates the rest of the item
                        int rest = (firstItem.itemValue + secondItem.itemValue) % firstItem.maxStack;

                        //fill up the other stack and adds the rest to the other stack 
                        if (!fitsIntoStack && rest > 0)
                        {
                            firstItem.itemValue = firstItem.maxStack;
                            secondItem.itemValue = rest;

                            firstItemGameObject.transform.SetParent(secondItemGameObject.transform.parent);
                            secondItemGameObject.transform.SetParent(oldSlot.transform);

                            firstItemRectTransform.localPosition = Vector3.zero;
                            secondItemRectTransform.localPosition = Vector3.zero;
                            cS.ListWithItem();
                        }
                    }

                }
                //if does not fit
                else
                {
                    //creates the rest of the item
                    int rest = 0;
                    if (sameItem)
                        rest = (firstItem.itemValue + secondItem.itemValue) % firstItem.maxStack;

                    //fill up the other stack and adds the rest to the other stack 
                    if (!fitsIntoStack && rest > 0)
                    {
                        secondItem.itemValue = firstItem.maxStack;
                        firstItem.itemValue = rest;

                        firstItemGameObject.transform.SetParent(secondItemGameObject.transform.parent);
                        secondItemGameObject.transform.SetParent(oldSlot.transform);

                        firstItemRectTransform.localPosition = Vector3.zero;
                        secondItemRectTransform.localPosition = Vector3.zero;
                        cS.ListWithItem();

                    }
                    //if they are different items or the stack is full, they get swapped
                    else if (!fitsIntoStack && rest == 0)
                    {
                        //if you are dragging an item from equipmentsystem to the inventory and try to swap it with the same itemtype
                        if (oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() != null && firstItem.itemType == secondItem.itemType)
                        {

                            SwapItemsPlaces(firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform);

                            ReturnToOriginalSlot(firstItemGameObject, firstItemRectTransform);
                        }
                        //if you are dragging an item from the equipmentsystem to the inventory and they are not from the same itemtype they do not get swapped.                                    
                        else if (oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() != null && firstItem.itemType != secondItem.itemType)
                        {
                            firstItemGameObject.transform.SetParent(oldSlot.transform);
                            firstItemRectTransform.localPosition = Vector3.zero;
                        }
                        //swapping for the rest of the inventorys
                        else if (oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() == null)
                        {
                            SwapItemsPlaces(firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform);
                        }
                    }

                }
            }
            else
            {
                if (newSlot.tag != "Slot" && newSlot.tag != "ItemIcon")
                {
                    firstItemGameObject.transform.SetParent(oldSlot.transform);
                    firstItemRectTransform.localPosition = Vector3.zero;
                }
                else
                {
                    firstItemGameObject.transform.SetParent(newSlot.transform);
                    firstItemRectTransform.localPosition = Vector3.zero;

                    if (newSlot.transform.parent.parent.GetComponent<EquipmentSystem>() == null && oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() != null)
                        oldSlot.transform.parent.parent.GetComponent<Inventory>().UnEquipItem1(firstItem);
                }
            }

        }
    }

    private void DragToFeed(GameObject firstItemGameObject, RectTransform firstItemRectTransform, Item firstItem, Item secondItem)
    {
        //drag from inventory to stables slot -> consume item and trigger feeding/happiness system
        if (firstItem.itemType == ItemType.Consumable && secondItem.itemType == ItemType.Horse)
        {
            Debug.Log("Horse fed!");
            inventory.OnUpdateItemList();
            Destroy(this.gameObject);
        }
        else
        {
            //ReturnToOriginalSlot(firstItemGameObject, firstItemRectTransform);
        }
    }
    private void DragToAddDecor()
    {
        //drag from decor catalogue to stables slot -> copy item into stables slot (includes a "None/Remove Decor" decor)
    }
    private void DragIntoEquipment(Transform newSlot, GameObject firstItemGameObject, GameObject secondItemGameObject, RectTransform firstItemRectTransform, RectTransform secondItemRectTransform, Item firstItem, Item secondItem, bool sameItemRerferenced, GameObject Inventory)
    {
        if (Inventory.GetComponent<EquipmentSystem>() != null)
        {
            ItemType[] itemTypeOfSlots = GameObject.FindGameObjectWithTag("EquipmentSystem").GetComponent<EquipmentSystem>().itemTypeOfSlots;
            int newSlotChildCount = newSlot.transform.parent.childCount;
            bool isOnSlot = newSlot.transform.parent.GetChild(0).tag == "ItemIcon";
            bool sameItemType = firstItem.itemType == secondItem.itemType;

            //dragging on a slot where allready is an item on
            if (newSlotChildCount != 0 && isOnSlot)
            {
                //items getting swapped if they are the same itemtype
                if (sameItemType && !sameItemRerferenced) //
                {
                    Transform temp1 = secondItemGameObject.transform.parent.parent.parent;
                    Transform temp2 = oldSlot.transform.parent.parent;

                    SwapItemsPlaces(firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform);

                    if (!temp1.Equals(temp2))
                    {
                        if (firstItem.itemType == ItemType.UFPS_Weapon)
                        {
                            Inventory.GetComponent<Inventory>().UnEquipItem1(secondItem);
                            Inventory.GetComponent<Inventory>().EquiptItem(firstItem);
                        }
                        else
                        {
                            Inventory.GetComponent<Inventory>().EquiptItem(firstItem);
                            if (secondItem.itemType != ItemType.Backpack)
                                Inventory.GetComponent<Inventory>().UnEquipItem1(secondItem);
                        }
                    }
                }
                //if they are not from the same Itemtype the dragged one getting placed back
                //wrong item to swap equipment item with. bread into helmet slot = this = no
                else
                {
                    ReturnToOriginalSlot(firstItemGameObject, firstItemRectTransform);
                }

            }
            //if the slot is empty
            else
            {
                for (int i = 0; i < newSlot.parent.childCount; i++)
                {
                    if (newSlot.Equals(newSlot.parent.GetChild(i)))
                    {
                        //checking if it is the right slot for the item
                        //right item into equipment slot
                        if (itemTypeOfSlots[i] == transform.GetComponent<ItemOnObject>().item.itemType)
                        {
                            transform.SetParent(newSlot);
                            rectTransform.localPosition = Vector3.zero;

                            if (!oldSlot.transform.parent.parent.Equals(newSlot.transform.parent.parent))
                            {
                                Inventory.GetComponent<Inventory>().EquiptItem(firstItem);
                            }
                        }
                        //else it get back to the old slot
                        //wrong item into equipment slot
                        else
                        {
                            ReturnToOriginalSlot(firstItemGameObject, firstItemRectTransform);
                        }
                    }
                }
            }
        }
    }

    private void DragItemInInventory(Transform newSlot, GameObject firstItemGameObject, GameObject secondItemGameObject, RectTransform firstItemRectTransform, RectTransform secondItemRectTransform, Item firstItem, Item secondItem, bool sameItem, bool sameItemRerferenced, bool secondItemStack, bool firstItemStack, GameObject Inventory)
    {
        if (Inventory.GetComponent<EquipmentSystem>() == null && Inventory.GetComponent<CraftSystem>() == null)
        {
            //you cannot attach items to the resultslot of the craftsystem
            if (newSlot.transform.parent.tag == "ResultSlot" || newSlot.transform.tag == "ResultSlot" || newSlot.transform.parent.parent.tag == "ResultSlot")
            {
                ReturnToOriginalSlot(firstItemGameObject, firstItemRectTransform);
            }
            else
            {
                int newSlotChildCount = newSlot.transform.parent.childCount;
                bool isOnSlot = newSlot.transform.parent.GetChild(0).tag == "ItemIcon";
                //dragging on a slot where allready is an item on
                if (newSlotChildCount != 0 && isOnSlot)
                {
                    //check if the items fits into the other item
                    bool fitsIntoStack = false;
                    if (sameItem)
                        fitsIntoStack = (firstItem.itemValue + secondItem.itemValue) <= firstItem.maxStack;
                    //if the item is stackable checking if the firstitemstack and seconditemstack is not full and check if they are the same items

                    if (inventory.stackable && sameItem && firstItemStack && secondItemStack)
                    {
                        //if the item does not fit into the other item
                        if (fitsIntoStack && !sameItemRerferenced)
                        {
                            secondItem.itemValue = firstItem.itemValue + secondItem.itemValue;
                            secondItemGameObject.transform.SetParent(newSlot.parent.parent);
                            Destroy(firstItemGameObject);
                            secondItemRectTransform.localPosition = Vector3.zero;
                        }

                        else
                        {
                            //creates the rest of the item
                            int rest = (firstItem.itemValue + secondItem.itemValue) % firstItem.maxStack;

                            //fill up the other stack and adds the rest to the other stack 
                            if (!fitsIntoStack && rest > 0)
                            {
                                firstItem.itemValue = firstItem.maxStack;
                                secondItem.itemValue = rest;

                                SwapItemsPlaces(firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform);
                            }
                        }

                    }
                    //if does not fit
                    else
                    {
                        //creates the rest of the item
                        int rest = 0;
                        if (sameItem)
                            rest = (firstItem.itemValue + secondItem.itemValue) % firstItem.maxStack;

                        //fill up the other stack and adds the rest to the other stack 
                        if (!fitsIntoStack && rest > 0)
                        {
                            secondItem.itemValue = firstItem.maxStack;
                            firstItem.itemValue = rest;

                            SwapItemsPlaces(firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform);
                        }
                        //if they are different items or the stack is full, they get swapped
                        else if (!fitsIntoStack && rest == 0)
                        {
                            //if you are dragging an item from equipmentsystem to the inventory and try to swap it with the same itemtype
                            if (oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() != null && firstItem.itemType == secondItem.itemType)
                            {
                                ReEquipNewItem(newSlot, firstItem, secondItem);

                                SwapItemsPlaces(firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform);
                            }
                            //if you are dragging an item from the equipmentsystem to the inventory and they are not from the same itemtype they do not get swapped.                                    
                            else if (oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() != null && firstItem.itemType != secondItem.itemType)
                            {
                                //Debug.Log("yes the thing ran. it's here.");
                                ReturnToOriginalSlot(firstItemGameObject, firstItemRectTransform);
                            }
                            //swapping for the rest of the inventorys
                            else if (oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() == null)
                            {
                                SwapItemsPlaces(firstItemGameObject, secondItemGameObject, firstItemRectTransform, secondItemRectTransform);
                            }
                        }
                    }
                }

                //empty slot
                else
                {
                    //non valid slot = put item back
                    if (newSlot.tag != "Slot" && newSlot.tag != "ItemIcon")
                    {
                        ReturnToOriginalSlot(firstItemGameObject, firstItemRectTransform);
                    }
                    //valid empty slot = put it in new slot
                    else
                    {
                        firstItemGameObject.transform.SetParent(newSlot.transform);
                        firstItemRectTransform.localPosition = Vector3.zero;

                        if (newSlot.transform.parent.parent.GetComponent<EquipmentSystem>() == null && oldSlot.transform.parent.parent.GetComponent<EquipmentSystem>() != null)
                            oldSlot.transform.parent.parent.GetComponent<Inventory>().UnEquipItem1(firstItem);
                    }
                }
            }
        }
    }

    private void ReEquipNewItem(Transform newSlot, Item firstItem, Item secondItem)
    {
        newSlot.transform.parent.parent.parent.parent.GetComponent<Inventory>().UnEquipItem1(firstItem);
        oldSlot.transform.parent.parent.GetComponent<Inventory>().EquiptItem(secondItem);
    }

    private void SwapItemsPlaces(GameObject firstItemGameObject, GameObject secondItemGameObject, RectTransform firstItemRectTransform, RectTransform secondItemRectTransform)
    {
        firstItemGameObject.transform.SetParent(secondItemGameObject.transform.parent);
        secondItemGameObject.transform.SetParent(oldSlot.transform);
        secondItemRectTransform.localPosition = Vector3.zero;
        firstItemRectTransform.localPosition = Vector3.zero;
    }
    private void ReturnToOriginalSlot(GameObject firstItemGameObject, RectTransform firstItemRectTransform)
    {
        firstItemGameObject.transform.SetParent(oldSlot.transform);
        firstItemRectTransform.localPosition = Vector3.zero;
    }
}
