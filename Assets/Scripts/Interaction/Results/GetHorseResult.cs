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
        Debug.Log($"inventorySO is {inventorySO}");

        if (MinigameTimer.Instance != null)
        {
            //MinigameTimer.Instance.OnMinigameReset += Execute;
        }
    }
    public void Execute()
    {
        item = horseSO.CreateItem();
        inventorySO.AddItem(item, 1);
        Debug.Log("Horse granted!");

        //anything else fancy
    }
}
