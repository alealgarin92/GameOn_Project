using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubePickup : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Sube sube;
    private void OnTriggerStay(Collider other)
    {
        var colliderGameObject = other.gameObject;
        //Necesito chequear la tag/label/etiqueta de el gameobject

        MainCharacter player = colliderGameObject.GetComponent<MainCharacter>();

        if (player != null) //Tiene el componente player
        {
            if (Input.GetKey(KeyCode.F) && sube != null)
            {
                PlayPickupSube();
                sube.Disapear();
                player.cantSube += 1;
            }
        }
    }

    private void PlayPickupSube()
    {
        audioSource.Play();
    }
}
