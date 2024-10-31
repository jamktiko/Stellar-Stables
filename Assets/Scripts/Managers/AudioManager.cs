using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float fadeDuration = 1.0f;

    private AudioClip targetClip;
     
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip newClip)
    {
        if (newClip == null)
        {
            StartCoroutine(FadeOut());
            return;
        }

        // If the clip is already playing, don’t restart it
        if (audioSource.clip == newClip && audioSource.isPlaying)
        {
            return;
        }

        // Otherwise, start fading to the new clip
        StartCoroutine(FadeToNewClip(newClip));
    }

    private IEnumerator FadeToNewClip(AudioClip newClip)
    {
        if (audioSource.isPlaying)
        {
            yield return StartCoroutine(FadeOut());
        }

        audioSource.clip = newClip;
        audioSource.Play();
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    private IEnumerator FadeIn()
    {
        audioSource.volume = 0;
        float targetVolume = 1.0f;

        while (audioSource.volume < targetVolume)
        {
            audioSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }
}
