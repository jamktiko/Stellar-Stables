using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GiveItemResult : MonoBehaviour, IResult
{
    public UserInterface userInterface;
    [SerializeField] private ItemObject itemSO;
    [SerializeField] private int itemValue;
    private Item item;

    public void Execute()
    {
        item = item ?? itemSO.CreateItem();
        userInterface.inventory.AddItem(item, itemValue);
    }
}
