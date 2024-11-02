using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubeArea : MonoBehaviour
{
    [SerializeField] private float dinero;
    [SerializeField] private AudioClip audiomonedas;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerStay(Collider other)
    {

        CargaSube(other.gameObject);
    }
    private void CargaSube(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            mainCharacter.CargaSube(dinero * Time.fixedDeltaTime);
            Playmonedas();
        }
    }
    public void Playmonedas()
    {
        audioSource.PlayOneShot(audiomonedas);
    }

}
