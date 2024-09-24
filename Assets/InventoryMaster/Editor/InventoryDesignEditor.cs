﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CustomEditor(typeof(InventoryDesign))]
public class InventoryDesignEditor : Editor
{
    InventoryDesign invDesign;
    Image slotDesign;

    bool showTitleFont;
    bool slotDesignFoldOut;
    bool inventoryDesignFoldOut;
    bool inventoryBackgroundDesignFoldOut;

    SerializedProperty inventoryTitle;
    SerializedProperty inventoryTitlePosX;
    SerializedProperty inventoryTitlePosY;
    SerializedProperty panelSizeX;
    SerializedProperty panelSizeY;    

    int fontStyleOfInventory;

    private int imageTypeIndex = 2;
    private int imageTypeIndexForInventory = 2;
    private int imageTypeIndexForInventory2 = 2;

    void OnEnable()
    {
        invDesign = target as InventoryDesign;
        invDesign.setVariables();
        inventoryTitlePosX = serializedObject.FindProperty("inventoryTitlePosX");
        inventoryTitlePosY = serializedObject.FindProperty("inventoryTitlePosY");
        panelSizeX = serializedObject.FindProperty("panelSizeX");
        panelSizeY = serializedObject.FindProperty("panelSizeY");
        inventoryTitle = serializedObject.FindProperty("inventoryTitle");        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.BeginVertical("Box");        
        EditorGUI.indentLevel++;
        inventoryDesignFoldOut = EditorGUILayout.Foldout(inventoryDesignFoldOut, "Inventory Design");
        if (inventoryDesignFoldOut)
        {               
            EditorGUI.BeginChangeCheck();
            inventoryTitle.stringValue = EditorGUILayout.TextField("Title", inventoryTitle.stringValue);
            EditorGUI.indentLevel++;
            GUILayout.BeginVertical("Box");
            showTitleFont = EditorGUILayout.Foldout(showTitleFont, "Font");
            if (showTitleFont)
            {
                EditorGUI.BeginChangeCheck();
                inventoryTitlePosX.intValue = EditorGUILayout.IntSlider("Position X:", inventoryTitlePosX.intValue, -panelSizeX.intValue / 2, panelSizeX.intValue);
                inventoryTitlePosY.intValue = EditorGUILayout.IntSlider("Position Y:", inventoryTitlePosY.intValue, -panelSizeY.intValue / 2, panelSizeX.intValue);
                if (EditorGUI.EndChangeCheck())
                {
                    invDesign.updateEverything();
                }
                EditorGUI.BeginChangeCheck();
                EditorGUI.indentLevel++;
                EditorGUILayout.TextArea("Character", EditorStyles.boldLabel);
                invDesign.inventoryTitleText.font = (Font)EditorGUILayout.ObjectField("Font", invDesign.inventoryTitleText.font, typeof(Font), true);                                                 //objectfield for the fonts
                string[] fontTypes = new string[4]; fontTypes[0] = "Normal"; fontTypes[1] = "Bold"; fontTypes[2] = "Italic"; fontTypes[3] = "BoldAndItalic";        //different fonttypes in a string array
                fontStyleOfInventory = EditorGUILayout.Popup("Font Style", fontStyleOfInventory, fontTypes, EditorStyles.popup);                        //a popout with the fontstyles
                if (fontStyleOfInventory == 0) { invDesign.inventoryTitleText.fontStyle = FontStyle.Normal; fontStyleOfInventory = 0; }                                  //sets the fontstyle in text 
                else if (fontStyleOfInventory == 1) { invDesign.inventoryTitleText.fontStyle = FontStyle.Bold; fontStyleOfInventory = 1; }
                else if (fontStyleOfInventory == 2) { invDesign.inventoryTitleText.fontStyle = FontStyle.Italic; fontStyleOfInventory = 2; }
                else if (fontStyleOfInventory == 3) { invDesign.inventoryTitleText.fontStyle = FontStyle.BoldAndItalic; fontStyleOfInventory = 3; }
                invDesign.inventoryTitleText.fontSize = EditorGUILayout.IntField("Font Size", invDesign.inventoryTitleText.fontSize);                                                                 //fontsize for the itemName
                invDesign.inventoryTitleText.lineSpacing = EditorGUILayout.FloatField("Line Spacing", invDesign.inventoryTitleText.lineSpacing);                                                      //linespacing for the itemName
                invDesign.inventoryTitleText.supportRichText = EditorGUILayout.Toggle("Rich Text", invDesign.inventoryTitleText.supportRichText);                                                     //support rich text for the itemName
                invDesign.inventoryTitleText.color = EditorGUILayout.ColorField("Color", invDesign.inventoryTitleText.color);                                                                         //colorfield for different colors for the text
                invDesign.inventoryTitleText.material = (Material)EditorGUILayout.ObjectField("Material", invDesign.inventoryTitleText.material, typeof(Material), true);                             //material objectfield for the itemname
                EditorGUI.indentLevel--;
                GUILayout.Space(20);
                if (EditorGUI.EndChangeCheck())
                {
                    invDesign.updateEverything();
                }

            }
            GUILayout.EndVertical();
            if (EditorGUI.EndChangeCheck())
            {
                invDesign.updateEverything();
            }

            GUILayout.BeginVertical("Box");
            inventoryBackgroundDesignFoldOut = EditorGUILayout.Foldout(inventoryBackgroundDesignFoldOut, "Inventory Design");
            if (inventoryBackgroundDesignFoldOut)
            {
                EditorGUI.indentLevel++;
                EditorGUI.BeginChangeCheck();

                invDesign.inventoryDesign.sprite = (Sprite)EditorGUILayout.ObjectField("Source Image", invDesign.inventoryDesign.sprite, typeof(Sprite), true);
                invDesign.inventoryDesign.color = EditorGUILayout.ColorField("Color", invDesign.inventoryDesign.color);
                invDesign.inventoryDesign.material = (Material)EditorGUILayout.ObjectField("Material", invDesign.inventoryDesign.material, typeof(Material), true);
                string[] imageTypes = new string[4]; imageTypes[0] = "Filled"; imageTypes[1] = "Simple"; imageTypes[2] = "Sliced"; imageTypes[3] = "Tiled";
                imageTypeIndexForInventory = EditorGUILayout.Popup("Image Type", imageTypeIndexForInventory, imageTypes, EditorStyles.popup);
                if (imageTypeIndexForInventory == 0) { invDesign.inventoryDesign.type = Image.Type.Filled; imageTypeIndexForInventory = 0; }
                else if (imageTypeIndexForInventory == 1) { invDesign.inventoryDesign.type = Image.Type.Simple; imageTypeIndexForInventory = 1; }
                else if (imageTypeIndexForInventory == 2) { invDesign.inventoryDesign.type = Image.Type.Sliced; imageTypeIndexForInventory = 2; }
                else if (imageTypeIndexForInventory == 3) { invDesign.inventoryDesign.type = Image.Type.Tiled; imageTypeIndexForInventory = 3; }
                invDesign.inventoryDesign.fillCenter = EditorGUILayout.Toggle("Fill Center", invDesign.inventoryDesign.fillCenter);
                if (EditorGUI.EndChangeCheck())
                {
                    invDesign.updateEverything();
                }
                EditorGUI.indentLevel--;
            }
            GUILayout.EndVertical();

            EditorGUI.indentLevel--;
        }
        EditorGUI.indentLevel--;
        GUILayout.EndVertical();

        GUILayout.BeginVertical("Box");
        EditorGUI.indentLevel++;
        slotDesignFoldOut = EditorGUILayout.Foldout(slotDesignFoldOut, "Slot Design");
        if (slotDesignFoldOut)
        {
            try
            {
                EditorGUI.indentLevel++;
                EditorGUI.BeginChangeCheck();
                invDesign.slotDesign.sprite = (Sprite)EditorGUILayout.ObjectField("Source Image", invDesign.slotDesign.sprite, typeof(Sprite), true);
                invDesign.slotDesign.color = EditorGUILayout.ColorField("Color", invDesign.slotDesign.color);
                invDesign.slotDesign.material = (Material)EditorGUILayout.ObjectField("Material", invDesign.slotDesign.material, typeof(Material), true);
                string[] imageTypes = new string[4]; imageTypes[0] = "Filled"; imageTypes[1] = "Simple"; imageTypes[2] = "Sliced"; imageTypes[3] = "Tiled";
                imageTypeIndex = EditorGUILayout.Popup("Image Type", imageTypeIndex, imageTypes, EditorStyles.popup);
                if (imageTypeIndex == 0) { invDesign.slotDesign.type = Image.Type.Filled; imageTypeIndex = 0; }
                else if (imageTypeIndex == 1) { invDesign.slotDesign.type = Image.Type.Simple; imageTypeIndex = 1; }
                else if (imageTypeIndex == 2) { invDesign.slotDesign.type = Image.Type.Sliced; imageTypeIndex = 2; }
                else if (imageTypeIndex == 3) { invDesign.slotDesign.type = Image.Type.Tiled; imageTypeIndex = 3; }
                invDesign.slotDesign.fillCenter = EditorGUILayout.Toggle("Fill Center", invDesign.slotDesign.fillCenter);
                EditorGUI.indentLevel--;
                if (EditorGUI.EndChangeCheck())
                {
                    invDesign.updateEverything();
                    invDesign.updateAllSlots();
                }
            }
            catch { }
        }        
        EditorGUI.indentLevel--;
        serializedObject.ApplyModifiedProperties();
        SceneView.RepaintAll();
        GUILayout.EndVertical();
    }

}
