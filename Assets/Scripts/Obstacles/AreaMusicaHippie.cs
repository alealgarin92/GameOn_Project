using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMusicaHippie : MonoBehaviour
{ 
    [SerializeField] private AudioClip musicahippie;
    [SerializeField] private AudioSource audioSourcemusica;

    private void OnTriggerEnter(Collider other)
    {
        MusicaChica(other.gameObject);
    }
    private void MusicaChica(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            Playmusichippie();
        }
    }
    public void Playmusichippie()
    {
        audioSourcemusica.PlayOneShot (musicahippie);
    }
}
