using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Tarjeta : MonoBehaviour
{

    [SerializeField] private float dinero;

    private void Awake()
    {
        dinero = 0;
    }

    public void Recarga(float recargaDinero)
    {
        dinero += recargaDinero;

    }

}