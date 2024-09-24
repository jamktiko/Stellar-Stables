using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDragCondition : MonoBehaviour, ICondition
{
    public bool IsConditionMet()
    {
        return true;
    }

    void Drag()
    {
        //drag object then if success = consume, if fail = go back to inventory (dragtofeed type shit)
        //AND
        //drag object then if success = stays there, if fail = go back to inventory (equipment system usage)
    }
}
