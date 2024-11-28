using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class ClickWithItemCondition : MonoBehaviour, ICondition
{
    //public UserInterface userInterface;
    [SerializeField] private bool isItemConsumed;
    [SerializeField] private ItemObject itemSO;
    [SerializeField] private int itemAmount;
    private Item item;

    public bool IsConditionMet()
    {
        item = item ?? itemSO.CreateItem();
        
        for (int i = 0; i < StaticInterface.instance.inventory.Container.Items.Length; i++)
        {
            int itemInInventory = StaticInterface.instance.inventory.Container.Items[i].item.Id;
            int amountOfItem = StaticInterface.instance.inventory.Container.Items[i].amount;

            if (itemInInventory == item.Id && amountOfItem >= itemAmount)
            {
                if (isItemConsumed) 
                {
                    //this removes the WHOLE item. not just 1 if it's a stack. shouldnt matter much tho unless we intend to have stackable items
                    StaticInterface.instance.inventory.Container.Items[i].RemoveItem();
                }

                AnimationHandler.instance.ItemFeedback(itemSO.uiDisplay, true);
                return true;
            }
        }
        return false;
    }
}
