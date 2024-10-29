using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CargarTarjeta : MonoBehaviour
{
    [SerializeField] private float pesos;


    private void OnTriggerStay(Collider other)
    {
        Recarga(other.gameObject);

    }

    public void Recarga(GameObject tarjetasube)

    {
        var TarjetaSube = tarjetaSube.GetComponent<Tarjeta>();
        if (tarjetaSube != null)
        {
            TarjetaSube.Recarga(pesos * Time.fixedDeltaTime);
        }
    }


}


   
