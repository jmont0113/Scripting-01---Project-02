using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{ 
    public static AudioManager Instance = null;

    AudioSource audioSource = null;

    public UnityEvent OnMusicLoop;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.Play();
    }
}

