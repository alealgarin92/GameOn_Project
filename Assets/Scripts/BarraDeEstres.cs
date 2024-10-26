using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraDeEstres : MonoBehaviour
{
    public Image barraDeEstres;
    public float nivelActual;
    public float nivelMaximo;

    void Update()
    {
        barraDeEstres.fillAmount = nivelActual/nivelMaximo;
    }
}
