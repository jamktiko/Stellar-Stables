﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;                                     //itemName of the item
    public int itemID;                                          //itemID of the item
    public string itemDesc;                                     //itemDesc of the item
    public Sprite itemIcon;                                     //itemIcon of the item
    public int itemValue = 1;                                   //itemValue is at start 1
    public ItemType itemType;                                   //itemType of the Item
    public int maxStack = 1;
    public int indexItemInList = 999;    
    public Item(){}

    public Item(string name, int id, string desc, Sprite icon, int maxStack, ItemType type)                 //function to create a instance of the Item
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = icon;
        itemType = type;
        this.maxStack = maxStack;
    }

    public Item getCopy()
    {
        return (Item)this.MemberwiseClone();        
    }   
}