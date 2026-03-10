using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MainSceneAudioSource;

    private static AudioManager instance;

    public static AudioManager Get()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<AudioManager>();
        }
        return instance;
    }

    public void Play(AudioClip clip)
    {
        if (clip == null || MainSceneAudioSource == null) return;

        MainSceneAudioSource.clip = clip;
        MainSceneAudioSource.Play();
    }

    public void Pause()
    {
        if (MainSceneAudioSource == null) return;

        MainSceneAudioSource.Pause();
    }

    public void ShutDown()
    {
        if (MainSceneAudioSource == null) return;

        MainSceneAudioSource.Stop();
        MainSceneAudioSource.clip = null;
    }    
}
