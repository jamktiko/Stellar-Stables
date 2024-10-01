using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UserInterface), true)]
public class InterfaceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default Inspector UI
        DrawDefaultInspector();

        // Get reference to the target script
        UserInterface userInterface = (UserInterface)target;

        // Add a button to the Inspector
        if (GUILayout.Button("Force create slots in Editor"))
        {
            userInterface.SetInventoryParent();
            userInterface.CreateSlots();
        }
    }
}
