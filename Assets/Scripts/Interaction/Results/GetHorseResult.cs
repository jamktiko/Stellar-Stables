using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InteractableObject))]

public class GetHorseResult : MonoBehaviour, IResult
{
    [Header("This gives an item directly to the Stables' inventory.")]
    [SerializeField] private ItemObject horseSO;
    private InventoryObject inventorySO;
    private Item item;

    private void Start()
    {
        inventorySO = Resources.Load<InventoryObject>("Inventory/Stables Inventory");
    }
    public void Execute()
    {
        item = item ?? horseSO.CreateItem();
        inventorySO.AddItem(item, 1);

        //anything else fancy
    }
}
