using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Fish
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "fishing_rod" && !_isRodReset)
        {
            collision.gameObject.GetComponent<RodMovementHandler>().Punish();
            Catch();
        }
    }
    override public void Catch()
    {
        Debug.Log("Obstacle caught.");
        Destroy(gameObject);
    }

}
