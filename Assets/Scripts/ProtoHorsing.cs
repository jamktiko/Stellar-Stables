using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProtoHorsing : MonoBehaviour
{
    public GameObject home;
    public GameObject world;
    public GameObject stables;

    [Header("Horse")]
    public GameObject horse;
    public GameObject pigeon;
    public GameObject frowny;
    public GameObject happy;
    public GameObject horseButton;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void GoToWorld()
    {
        home.SetActive(false);
        stables.SetActive(false);
        world.SetActive(true);
    }

    public void GoToHome()
    {
        home.SetActive(true);
        stables.SetActive(false);
        world.SetActive(false);
    }

    public void GoToStables()
    {
        home.SetActive(false);
        stables.SetActive(true);
        world.SetActive(false);
    }

    public void UnlockHorse()
    {
        horse.SetActive(true);
        Destroy(horseButton);
    }
    public void ObtainFood()
    {
        pigeon.SetActive(true);
    }

    public void FeedHorse()
    {
        pigeon.SetActive(false);
        frowny.SetActive(false);
        happy.SetActive(true);
    }
}
