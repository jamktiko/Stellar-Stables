using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ManageItems))]
public class ManageItemsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default Inspector UI
        DrawDefaultInspector();

        // Get reference to the target script
        ManageItems manageItems = (ManageItems)target;

        // Add a button to the Inspector
        if (GUILayout.Button("Add Item to Inventory (Takes time to load)"))
        {
            manageItems.AddItemToInventory();
        }

        if (GUILayout.Button("Remove Item from Inventory (Takes time to load)"))
        {
            manageItems.AddItemToInventory();
        }
    }
}
