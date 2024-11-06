using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource soundPlayer;

    public void PlayThisSoundEffect()
    {
        soundPlayer.Play();
    }
}
