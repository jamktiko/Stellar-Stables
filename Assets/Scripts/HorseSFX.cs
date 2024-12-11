using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSFX : MonoBehaviour
{
    public ItemObject horseSO;
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] audioClips;
    public void PlaySFX()
    {
        Debug.Log("horseSO is null: " + (horseSO == null));

        if (horseSO != null)
        {
            int randomClipIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomClipIndex];
            audioSource.Play();
        }
        else
        {
            Debug.Log("slot empty or missing clip for horse SO");
        }
    }
}
