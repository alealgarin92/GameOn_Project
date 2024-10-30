using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Tarjeta : MonoBehaviour
{

    [SerializeField] private float dinero;

    private void Update()
    {
        Recarga(dinero);
    }


    public void Recarga(float pesos)
    {
        dinero += pesos;

    }

}