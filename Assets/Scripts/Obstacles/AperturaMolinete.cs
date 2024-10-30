using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molinete : MonoBehaviour
{
    [SerializeField] private Animator molinetedoor;
    [SerializeField] private float restaSaldo;

    
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
        ApoyaSube(other.gameObject);
    }

    private void ApoyaSube(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            if(mainCharacter.saldoSube > 300)
            {
                mainCharacter.ApoyaSube(restaSaldo * Time.fixedDeltaTime);
                Opendoor();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}