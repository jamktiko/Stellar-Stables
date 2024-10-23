using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(DebugInventory))]
public class DebugInventoryEditor : Editor
{
    int selectedSlotIndex = 0;
    public override void OnInspectorGUI()
    {
        // Draw the default Inspector UI
        DrawDefaultInspector();

        // Get reference to the target script
        DebugInventory manageItems = (DebugInventory)target;

        if (manageItems.userInterface != null)
        {
            int slotsCount = manageItems.userInterface.slotsOnInterface.Count;

            manageItems.FindInterface();

            // Add an integer slider for selecting the slot index (0-4)
            selectedSlotIndex = EditorGUILayout.IntSlider("Slot Index", selectedSlotIndex, 0, slotsCount - 1);

            // Add a button to the Inspector
            if (GUILayout.Button("Add Item to Inventory"))
            {
                manageItems.AddItemToInventory();
            }

            // Button for removing an item at the selected slot index
            if (GUILayout.Button("Remove Item from Inventory at Slot[" + (selectedSlotIndex + 1) + "]"))
            {
                manageItems.RemoveItemFromInventory(selectedSlotIndex);
            }

            if (GUILayout.Button("Clear ALL items from Inventory"))
            {
                manageItems.ClearInventory();
            }
        }
    }
} 
#endif
