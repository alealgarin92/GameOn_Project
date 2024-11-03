using UnityEngine;
using System.Collections;

public class CloseMolinete : MonoBehaviour
{
    [SerializeField] private Animator molinetedoor;
    [SerializeField] private AudioClip sonidopuerta;
    [SerializeField] private AudioSource audioSource;

    public void Opendoor()
    {
        molinetedoor.SetBool("Abrir", true);
    }

    public void Closedoor()
    {
        molinetedoor.SetBool("Abrir", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        CierreMolinete(other.gameObject);
    }

    private void CierreMolinete(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            Closedoor();
            Closesound();
            Destroy(gameObject);
        }
    }
    public void Closesound()
    {
        audioSource.PlayOneShot(sonidopuerta);
    }
}
