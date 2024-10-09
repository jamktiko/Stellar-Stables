using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(GiveItemResult))]
public class GiveItemEditor : Editor
{
    //public GiveItemResult giveItemResult;
    //SerializedProperty itemID;
    //SerializedProperty itemValue;
    //void OnEnable()
    //{
    //    giveItemResult = target as GiveItemResult;
    //    itemID = serializedObject.FindProperty("itemID");
    //    itemValue = serializedObject.FindProperty("itemValue");
    //}

    //public override void OnInspectorGUI()
    //{
    //    base.DrawDefaultInspector();
    //    serializedObject.Update();
    //    SelectItemGUI();
    //    serializedObject.ApplyModifiedProperties();
    //}

    //public void SelectItemGUI()
    //{
    //    GUILayout.Label("Item to give:");                                                                                 //space to the top gui element
    //    EditorGUILayout.BeginHorizontal();                                                                                  //starting horizontal GUI elements

    //    ItemDataBaseList inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");                              //loading the itemdatabase
    //    string[] items = new string[inventoryItemList.itemList.Count];                                                      //create a string array in length of the itemcount
    //    for (int i = 1; i < items.Length; i++)                                                                              //go through the item array
    //    {
    //        items[i] = inventoryItemList.itemList[i].itemName;                                                              //and paste all names into the array
    //    }

    //    itemID.intValue = EditorGUILayout.Popup("", itemID.intValue, items, EditorStyles.popup);                                              //create a popout with all itemnames in it and save the itemID of it
    //    itemValue.intValue = EditorGUILayout.IntField("", itemValue.intValue, GUILayout.Width(40));

    //    //giveItemResult.SetVariablesThroughEditor(itemID.intValue, itemValue.intValue);

    //    EditorGUILayout.EndHorizontal();                                                                                    //end the horizontal gui layout
    //}
} 
#endif
