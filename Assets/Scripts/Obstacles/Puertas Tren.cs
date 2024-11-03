using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaTren : MonoBehaviour
{
    [SerializeField] private Animator animatorPuertas;

    public void AbrePuerta()
    {
        animatorPuertas.SetBool("Abre", true);
    }

    public void CierraPuerta()
    {
        animatorPuertas.SetBool("Abre", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        Puertasabiertas(other.gameObject);
    }

    public void Puertasabiertas(GameObject target)
    {
        Tren tren = target.GetComponent<Tren>();
        if (tren != null)
        {
           Destroy(gameObject);
           AbrePuerta();
        }
    }
}


