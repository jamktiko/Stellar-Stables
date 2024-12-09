using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip audioClip;
    public void PlaySFX()
    {
        if (TryGetComponent(out HorseAnimationHandler horseAnimHandler))
        {
            if (horseAnimHandler.horseSO != null)
            {
                ItemObject currentHorse = horseAnimHandler.horseSO;
                audioClip = currentHorse.data.horseSFXClip;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            else
            {
                Debug.Log("slot empty or missing clip for horse SO");
            }
        }
    }
}
