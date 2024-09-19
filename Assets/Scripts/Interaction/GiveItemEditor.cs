using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[CustomEditor(typeof(GiveItemResult))]
public class GiveItemEditor : Editor
{
    public GiveItemResult giveItemResult;
    [SerializeField] private int itemID;
    [SerializeField] private int itemValue = 1;
    void OnEnable()
    {
        giveItemResult = target as GiveItemResult;
    }

    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        serializedObject.Update();
        SelectItemGUI();
        serializedObject.ApplyModifiedProperties();
    }

    public void SelectItemGUI()
    {
        GUILayout.Label("Item to give:");                                                                                 //space to the top gui element
        EditorGUILayout.BeginHorizontal();                                                                                  //starting horizontal GUI elements
        ItemDataBaseList inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");                              //loading the itemdatabase
        string[] items = new string[inventoryItemList.itemList.Count];                                                      //create a string array in length of the itemcount
        for (int i = 1; i < items.Length; i++)                                                                              //go through the item array
        {
            items[i] = inventoryItemList.itemList[i].itemName;                                                              //and paste all names into the array
        }
        itemID = EditorGUILayout.Popup("", itemID, items, EditorStyles.popup);                                              //create a popout with all itemnames in it and save the itemID of it
        itemValue = EditorGUILayout.IntField("", itemValue, GUILayout.Width(40));

        giveItemResult.SetVariablesThroughEditor(itemID, itemValue);

        EditorGUILayout.EndHorizontal();                                                                                    //end the horizontal gui layout
    }
}
