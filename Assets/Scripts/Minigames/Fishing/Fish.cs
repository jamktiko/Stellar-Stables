using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, ICatchable
{

    protected bool _isRodReset = false;

    private void OnEnable()
    {
        RodMovementHandler.Instance.OnRodReset += ToggleResetOn;
        RodMovementHandler.Instance.OnRodEnable += ToggleResetOff;
    }

    private void OnDisable()
    {
        RodMovementHandler.Instance.OnRodReset -= ToggleResetOn;
        RodMovementHandler.Instance.OnRodEnable -= ToggleResetOff;
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
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

    virtual public void Catch()
    {
        Debug.Log("Fish caught.");
        MinigameScore.Instance.AddScore();
        Destroy(gameObject);
    }

    private void ToggleResetOn()
    {
        _isRodReset = true;
        Debug.Log("Log reset set to: " + _isRodReset);
    }

    private void ToggleResetOff()
    {
        _isRodReset = false;
        Debug.Log("Log reset set to: " + _isRodReset);
    }

}
