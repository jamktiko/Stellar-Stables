using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Draggable : DraggingHandler
{
    //i dont think this needs to be Component anymore
    //dum
    [SerializeField] private List<Component> dragOntoConditions;
    public void Start()
    {
        DragOntoCondition[] conditions = GetComponents<DragOntoCondition>();
        dragOntoConditions.AddRange(conditions);

        SetupPointerLogic();
    }
    private void SetupPointerLogic()
    {
        InitializeEvents(gameObject, gameObject);

        if (TryGetComponent(out InteractableObject interactableObject))
        {
            SetupDragConditions();
        }
    }

    private void SetupDragConditions()
    {
        List<string> allTags = new List<string>();

        allTags.AddRange(dragOntoConditions
            .Select(c => (c as DragOntoCondition)?.targetObjectTag)
            .Where(t => t != null));


        foreach (string tag in allTags)
        {
            if (tag != "")
            {
                GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject obj in taggedObjects)
                {
                    InitializeEvents(obj);
                }
            }
        }

        foreach (var condition in dragOntoConditions)
        {
            var dragCondition = condition as DragOntoCondition;
            if (dragCondition != null && dragCondition.objectToDragOnto != null)
            {
                InitializeEvents(dragCondition.objectToDragOnto);
            }
        }
    }

    public override void OnDragEnd(GameObject obj)
    {
        base.OnDragEnd(obj);
        GetComponent<RectTransform>().position = Input.mousePosition;
        //GetComponent<InteractableObject>().CheckConditions();
        if (TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.CheckConditions();
        }
    }
}
