using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlavePickup : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Llave llave;
    private void OnTriggerStay(Collider other)
    {
        var colliderGameObject = other.gameObject;
        //Necesito chequear la tag/label/etiqueta de el gameobject

        MainCharacter player = colliderGameObject.GetComponent<MainCharacter>();

        if (player != null) //Tiene el componente player
        {
            if (Input.GetKey(KeyCode.F) && llave != null)
            {
                PlayPickupKeys();
                llave.Disapear();
                player.cantLlaves += 1;
                
            }
            
        }
    }

    private void PlayPickupKeys()
    {
        audioSource.Play();
    }
}
