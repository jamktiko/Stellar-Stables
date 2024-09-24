using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, ICatchable
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "fishing_rod")
        {
            Catch();    

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Catch()
    {
        Debug.Log("Fish caught.");
        FishScore.Instance.AddScore();
        Destroy(gameObject);
    }

}
