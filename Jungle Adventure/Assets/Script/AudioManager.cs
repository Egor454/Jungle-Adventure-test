﻿using UnityEngine;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    [SerializeField] private AudioSource audioSourceForFonMusic;
    [SerializeField] private AudioSource audioSourceForButton;
    [SerializeField] AudioClip musicMainMenu;
    [SerializeField] AudioClip musicLevel1;
    [SerializeField] AudioClip musicLevel2;
    [SerializeField] AudioClip musicLevel3;
    [SerializeField] AudioClip musicLevel4;
    [SerializeField] AudioClip ButtonClickMusic;
    private bool musicSettings;
    private bool soundSettings;


    private void Awake()
    {
        AudioSource audioSourceFon = gameObject.AddComponent<AudioSource>();
        AudioSource audioSourceButton = gameObject.AddComponent<AudioSource>();
        audioSourceForFonMusic = audioSourceFon;
        audioSourceForFonMusic.loop = true;
        audioSourceForButton = audioSourceButton;
        musicMainMenu = (AudioClip)Resources.Load("Music/MainMusicMenu");
        musicLevel1 = (AudioClip)Resources.Load("Music/Level1Music");
        musicLevel2 = (AudioClip)Resources.Load("Music/Level2Music");
        musicLevel3 = (AudioClip)Resources.Load("Music/Level3Music");
        musicLevel4 = (AudioClip)Resources.Load("Music/Level4Music");
        ButtonClickMusic = (AudioClip)Resources.Load("Music/ButtonClick");

        musicSettings = System.Convert.ToBoolean(PlayerPrefs.GetString("MusicSettings"));
        soundSettings = System.Convert.ToBoolean(PlayerPrefs.GetString("SoundSettings"));
    }
    void Update()
    {

    }
    public void FonMusic(int sceneIndex)
    {
        if (musicSettings)
        {
            if (sceneIndex == 0)
            {
                audioSourceForFonMusic.clip = musicMainMenu;
                audioSourceForFonMusic.Play();

            }
            else if (sceneIndex == 1)
            {
                audioSourceForFonMusic.clip = musicLevel1;
                audioSourceForFonMusic.Play();
            }
            else if (sceneIndex == 2)
            {
                audioSourceForFonMusic.clip = musicLevel2;
                audioSourceForFonMusic.Play();
            }
            else if (sceneIndex == 3)
            {
                audioSourceForFonMusic.clip = musicLevel3;
                audioSourceForFonMusic.Play();
            }
            else if (sceneIndex == 4)
            {
                audioSourceForFonMusic.clip = musicLevel4;
                audioSourceForFonMusic.Play();
            }
        }

    }
    public void ChangeMusicSettings()
    {
        musicSettings = System.Convert.ToBoolean(PlayerPrefs.GetString("MusicSettings"));
        if (!musicSettings)
        {
            audioSourceForFonMusic.Stop();
        }
        else
        {
            audioSourceForFonMusic.Play();
            FonMusic(0);
        }
    }
    public void ChangeSoundSettings()
    {
        soundSettings = System.Convert.ToBoolean(PlayerPrefs.GetString("SoundSettings"));
    }
    public void ButtonClick()
    {
        if (soundSettings)
        {
            audioSourceForButton.PlayOneShot(ButtonClickMusic);
        }
    }
}
