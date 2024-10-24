using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInterface : UserInterface
{
    public GameObject[] slots;
    public static StaticInterface instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log($"StaticInterface is: {StaticInterface.instance.gameObject.name}");
        }
        else if (instance != this)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }
    }

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
