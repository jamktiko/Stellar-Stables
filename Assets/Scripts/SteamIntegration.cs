using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{
    void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(3286080);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
    private void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }
    private void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }
}
