using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Note")
        {
            MinigameLives.Instance.UseLife();
            Destroy(collision.gameObject);
        }
    }
}
