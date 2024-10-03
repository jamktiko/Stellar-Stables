﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInterface : UserInterface
{
    public GameObject[] slots;

    public override void CreateSlots()
    {
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = slots[i];

            InitializeEvents(gameObject, obj, slotsOnInterface);

            slotsOnInterface.Add(obj, inventory.Container.Items[i]);
        }
    }
}
