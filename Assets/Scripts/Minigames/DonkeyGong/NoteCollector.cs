using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollector : MonoBehaviour
{
    private void OnMouseDown()
    {
        CollectNote();
    }

    private void CollectNote()
    {
        Debug.Log("Note collected");

        Destroy(gameObject);
    }

}
