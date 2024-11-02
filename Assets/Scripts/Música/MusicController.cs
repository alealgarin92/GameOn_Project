using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource mainAudio;

    [SerializeField] private AudioClip level1, level2, level3;


    public void ChangeMusic(AudioClip newClip)
    {
        mainAudio.Stop();

        mainAudio.clip = newClip;

        mainAudio.Play();
    }

    public void PlayLevel1Music()
    {
        ChangeMusic(level1);
    }

    public void PlayLevel2Music()
    {
        ChangeMusic(level2);
    }
    public void PlayLevel3Music()
    {
        ChangeMusic(level3);
    }
}  
