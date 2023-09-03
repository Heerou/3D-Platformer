using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor.Audio;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioManagerInstance;
    [SerializeField]
    int levelMusicToPlay;
    int currentTrack;
    public AudioSource[] Music;
    public AudioSource[] SoundFX;

    public AudioMixerGroup MusicMixer, SFXMixer;

    void Awake()
    {
        PlayMusic(0);
        //Debug.Log("la ultima posicion del array es: " + Convert.ToInt32(Music.Last()) + " que tiene un tamaño de: " + Convert.ToInt32(Music.Length));
    }

    void Start()
    {
        AudioManagerInstance = this;
        currentTrack = levelMusicToPlay;
    }

    void Update()
    {
        MusicPlayer();
    }

    public void PlayMusic(int musicToPlay)
    {
        for (int i = 0; i < Music.Length; i++)
        {
            Music[i].Stop();
        }
        Music[musicToPlay].Play();
    }

    public void PlaySoundFX(int sfxToPlay)
    {
        SoundFX[sfxToPlay].Play();
    }

    void MusicPlayer()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentTrack++;
            if (currentTrack > Music.Length - 1)
            {
                currentTrack = 0;
                PlayMusic(currentTrack);
            }
            else
            {
                PlayMusic(currentTrack);
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentTrack--;
            if (currentTrack < 0)
            {
                currentTrack = Convert.ToInt32(Music.Last());
                PlayMusic(currentTrack);
            }
            else
            {
                PlayMusic(currentTrack);
            }
        }
    }

    public void SetMusicLevel()
    {
        MusicMixer.audioMixer.SetFloat("MusicVol", UIManager.UI_Instance.MusicVolSlider.value);
    }
    public void SetSFXLevel()
    {
        SFXMixer.audioMixer.SetFloat("SFXVol", UIManager.UI_Instance.SFXVolSlider.value);
    }
}
