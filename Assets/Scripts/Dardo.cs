using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dardo : MonoBehaviour
{
    [SerializeField] private Transform dardo; 
    [SerializeField] private float dardoPickupDistance = 2.0f;
    [SerializeField] private Transform dardoHoldPosition; 
    private bool dardoAgarrado = false; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dardoAgarrado)
            {
                SoltarDardo();
            }
            else
            {
                IntentarAgarrarDardo();
            }
        }

        if (dardoAgarrado)
        {
            dardo.position = dardoHoldPosition.position;
        }
        
    }

    private void IntentarAgarrarDardo()
    {
        if (Vector3.Distance(transform.position, dardo.position) <= dardoPickupDistance)
        {
            dardoAgarrado = true;
            dardo.SetParent(dardoHoldPosition); 
            dardo.localPosition = Vector3.zero; 
        }
    }

    private void SoltarDardo()
    {
        dardoAgarrado = false;
        dardo.SetParent(null);
    }
}
