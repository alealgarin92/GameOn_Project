using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMusicaHippie : MonoBehaviour
{ 
    [SerializeField] private AudioClip musicahippie;
    [SerializeField] private AudioSource audioSourcemusica;
    [SerializeField] private Animator chicatocando;

    public void Tocamusica()
    {
        chicatocando.SetBool("Toca", true);
    }

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
            Tocamusica();
        }
    }
    public void Playmusichippie()
    {
        audioSourcemusica.PlayOneShot (musicahippie);
    }
}
