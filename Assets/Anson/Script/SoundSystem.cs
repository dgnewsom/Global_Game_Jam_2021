using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] List<Sound> sounds = new List<Sound>();
    [SerializeField] List<Sound> soundsCache = new List<Sound>();
    [SerializeField] AudioMixer audioMixer;

    private void Start()
    {
        UpdateSounds();
    }


    public void UpdateSounds()
    {
        List<Sound> newSounds = new List<Sound>(FindObjectsOfType<Sound>());
        sounds = new List<Sound>();
        foreach (Sound s in newSounds)
        {
            AddSounds(s);
            s.SoundSystem = this;
        }
    }

    public void AddSounds(Sound s)
    {
        if (!sounds.Contains(s))
        {
            if (s.AudioMixer == null)
            {
                s.AudioMixer = audioMixer;
            }
        }
    }

    public void PauseAllSounds()
    {
        soundsCache = new List<Sound>();
        foreach(Sound s in sounds)
        {
            if (s.IsPlaying())
            {
                soundsCache.Add(s);
                s.Pause();
            }
        }
    }

    public void ResumeSounds()
    {
        foreach(Sound s in soundsCache)
        {
            s.Resume();
        }
    }


    public void StopAllSounds()
    {
        soundsCache = new List<Sound>();
        foreach (Sound s in sounds)
        {
            if (s.IsPlaying())
            {
                soundsCache.Add(s);
                s.Stop();
            }
        }
    }

}
