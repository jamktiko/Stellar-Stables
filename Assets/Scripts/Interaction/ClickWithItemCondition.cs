using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickWithItemCondition : MonoBehaviour, ICondition
{
    public UserInterface userInterface;
    [SerializeField] private bool isItemConsumed;
    [SerializeField] private ItemObject itemSO;
    [SerializeField] private int itemValue;
    private Item item;

    public bool IsConditionMet()
    {
        item = item ?? itemSO.CreateItem();
        
        for (int i = 0; i < userInterface.inventory.Container.Items.Length; i++)
        {
            if (userInterface.inventory.Container.Items[i].item.Id == item.Id)
            {
                if (isItemConsumed) 
                { 
                    userInterface.inventory.Container.Items[i].RemoveItem(); 
                }
                return true;
            }
        }
        return false;
    }
}
