using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molinete : MonoBehaviour
{
    [SerializeField] private Animator molinetedoor;
    [SerializeField] private float restaSaldo;

    [ContextMenu("AbrirMolinete")]

    public void Opendoor()
    {
        molinetedoor.SetBool("Abrir", true);
    }

    [ContextMenu("Cerrarmolinete")]
    public void Closedoor()
    {
        molinetedoor.SetBool("Abrir", false);
    }

    private void OnTriggerStay(Collider other)
    {
        Sube(other.gameObject);

    }

    private void Sube(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            mainCharacter.Sube(restaSaldo * Time.fixedDeltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}