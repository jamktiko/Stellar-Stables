using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, ICatchable
{

    private bool _isRodReset = false;

    private void OnEnable()
    {
        RodMovementHandler.Instance.OnRodReset += ToggleReset;
        RodMovementHandler.Instance.OnRodEnable += ToggleReset;
    }

    private void OnDisable()
    {
        RodMovementHandler.Instance.OnRodReset -= ToggleReset;
        RodMovementHandler.Instance.OnRodEnable -= ToggleReset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "fishing_rod" && !_isRodReset)
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

    private void ToggleReset()
    {
        Debug.Log("Log reset set to: " + _isRodReset);
        _isRodReset = !_isRodReset;
    }

}
