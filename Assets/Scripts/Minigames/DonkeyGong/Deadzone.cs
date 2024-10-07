using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private float minimumDeadzoneSize;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Note")
        {
            MinigameLives.Instance.UseLife();
            if (transform.localScale.x > minimumDeadzoneSize)
            {
                transform.DOScale(transform.localScale - new Vector3(0.02f, 0.02f, 0.02f), 0.5f);
            }
            Destroy(collision.gameObject);
        }
    }

}
