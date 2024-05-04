using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip thunder;
    public AudioClip deathScream;
    public AudioClip vampireHiss;
    public AudioClip swordHit;
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    
    //private bool sfxPausedInMenu = false;
    // private bool isMuted = false;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
    
    /*
    public void MuteToggle()
    {
        isMuted = !isMuted;
        float musicVolume = musicSource.volume;
        float sfxVolume = sfxSource.volume;
        if (isMuted)
        {
            musicSource.volume = 0;
            sfxSource.volume = 0;
        }
        else
        {
            musicSource.volume = musicVolume;
            sfxSource.volume = sfxVolume;
        }
    }
    */
}