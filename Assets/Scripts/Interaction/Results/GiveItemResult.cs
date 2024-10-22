using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(InteractableObject))]
public class GiveItemResult : MonoBehaviour, IResult
{
    //public UserInterface userInterface;
    [Header("This gives an item directly to the Player's inventory. Does not work with Stables inventory")]
    [SerializeField] private ItemObject itemSO;
    [SerializeField] private int itemValue;
    private Item item;

    //private void Start()
    //{
    //    userInterface = GameObject.FindWithTag("MainInventory").GetComponent<UserInterface>();
    //}
    public void Execute()
    {
        item = item ?? itemSO.CreateItem();
        StaticInterface.instance.inventory.AddItem(item, itemValue);
    }
}
