using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CargarTarjeta : MonoBehaviour
{
    [SerializeField] private float pesos;


    private void OnTriggerEnter(Collider other)
    {
        Recarga(other.gameObject);

    }

    public void Recarga(GameObject tarjetasube)

    {
        Tarjeta tarjetaSube = tarjetasube.GetComponent<Tarjeta>();
        if (tarjetaSube != null)
        {
            tarjetaSube.Recarga(pesos * Time.fixedDeltaTime);
        }
    }
}


   
