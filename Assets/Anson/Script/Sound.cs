using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource source;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] SoundSystem soundSystem;

    public AudioMixer AudioMixer { get => audioMixer; set => audioMixer = value; }
    public SoundSystem SoundSystem { get => soundSystem; set => soundSystem = value; }

    private void Awake()
    {
        if (source == null && audioClip != null)
        {
            source = gameObject.AddComponent<AudioSource>();
            source.clip = audioClip;
        }
        if(soundSystem!= null)
        {
            soundSystem = FindObjectOfType<SoundSystem>();
        }
        source.clip = audioClip;
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }

    public void Pause()
    {
        source.Pause();
    }
    public void Resume()
    {
        source.UnPause();
    }
    public void Play()
    {
        if (!source.isPlaying)
        {
        source.Play();

        }
    }
    public void Stop()
    {
        source.Stop();
    }
}
