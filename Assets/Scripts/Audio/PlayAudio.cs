using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour, IResult
{

    public AudioSource soundPlayer;

    public void PlayThisSoundEffect()
    {
        soundPlayer.Play();
    }
    public void Execute()
    {
        soundPlayer.Play();
    }
}
