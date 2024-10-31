using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameLevelManager : MonoBehaviour
{
    public static MinigameLevelManager Instance { get; private set; }

    [SerializeField] private int fishLevelIndex = 1;
    public int FishLevelIndex
    {
        get
        {
            return fishLevelIndex;
        }
        set
        {
            if (value <= 4)
            {
                fishLevelIndex = value;
            }
        }
    }

    [SerializeField] private int musicLevelIndex = 1;
    public int MusicLevelIndex { 
        get 
        { 
            return musicLevelIndex; 
        }
        set 
        {
            if (value <= 4)
            {
                musicLevelIndex = value;
            }
        }
    }

    [SerializeField] private int twonyLevelIndex = 1;
    public int TwonyLevelIndex 
    {
        get 
        {
            return twonyLevelIndex;
        }
        set 
        {
            if(value <= 4)
            {
                twonyLevelIndex = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        FishLevelIndex = fishLevelIndex;
        MusicLevelIndex = musicLevelIndex;
        TwonyLevelIndex = twonyLevelIndex;
    }

}
