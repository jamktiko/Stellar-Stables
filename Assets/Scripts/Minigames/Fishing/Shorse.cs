using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shorse : Fish
{
    [Header("This gives an item directly to the Stables' inventory.")]
    [SerializeField] private ItemObject horseSO;
    private InventoryObject inventorySO;
    private Item item;

    private void Start()
    {
        inventorySO = Resources.Load<InventoryObject>("Inventory/Stables Inventory");
        Debug.Log($"inventorySO is {inventorySO}");
    }
    override public void Catch()
    {
        Debug.Log("Shorse caught!");
        item = horseSO.CreateItem();
        if (inventorySO == null)
        {
            Debug.LogError("InventorySO is null;");
        }
        else
        {
            inventorySO.AddItem(item, 1);
            MinigameLevelManager.Instance.FishLevelIndex++;
            HorseObtained.instance.StartPopup(horseSO);
        }
        Destroy(gameObject);
    }
}
