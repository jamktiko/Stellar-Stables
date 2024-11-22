using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(InteractableObject))]
public class GetHorseResult : MonoBehaviour, IResult
{
    [Header("This gives an item directly to the Stables' inventory.")]
    [SerializeField] private ItemObject[] horseSO;
    private InventoryObject inventorySO;
    private Item item;

    private void Start()
    {
        inventorySO = Resources.Load<InventoryObject>("Inventory/Stables Inventory");
        //Debug.Log($"inventorySO is {inventorySO}");
    }
    public void Execute()
    {
        item = horseSO[0].CreateItem();
        inventorySO.AddItem(item, 1);
        HorseFoundScreen.instance.StartPopup(horseSO[0]);
        Debug.Log("Horse granted!");
    }

    public void Execute(int horseIndex)
    {
        item = horseSO[horseIndex].CreateItem();
        inventorySO.AddItem(item, 1);
        HorseFoundScreen.instance.StartPopup(horseSO[horseIndex]);
        Debug.Log("Horse granted!");
    }
}
