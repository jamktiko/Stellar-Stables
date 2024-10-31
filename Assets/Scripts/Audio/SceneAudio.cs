using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{

    [SerializeField] private AudioClip sceneAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(sceneAudioClip);
    }

}
