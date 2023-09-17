using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx { }


    private void Awake()
    {
        instance = this;
        Init();
        PlayBgm(true);
    }

    void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int i=0;i<sfxPlayers.Length;i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = sfxVolume;
        }


    }

    public void PlayBgm(bool isPlay)
    {
        if(isPlay)
        {
            if(!bgmPlayer.isPlaying)
            {
                bgmPlayer.Play();
            }
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void SetBgmVolume(float volume)
    {
        bgmVolume = volume;
        bgmPlayer.volume = bgmVolume;
    }

    public float GetBgmVolume()
    {
        return bgmVolume;
    }

    public void SetSfxVolume(float volume)
    {
        sfxVolume = volume;

        foreach(AudioSource sfxPlayer in sfxPlayers)
        {
            sfxPlayer.volume = sfxVolume;
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for(int i = 0; i < sfxPlayers.Length;i++)
        {
            int loop = (i + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loop].isPlaying)
            {
                continue;
            }

            channelIndex = loop;

            sfxPlayers[loop].clip = sfxClips[(int)sfx];
            sfxPlayers[loop].Play();
            break;
        }
    }



}
