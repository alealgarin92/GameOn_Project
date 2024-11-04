using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dardo : MonoBehaviour
{
    // Dentro de la clase MainCharacter
    [SerializeField] private Transform dardo; // Asigna aquí el dardo en el Inspector
    [SerializeField] private float dardoPickupDistance = 2.0f;
    [SerializeField] private Transform dardoHoldPosition; // Posición donde el dardo se "sujeta" al personaje
    private bool dardoAgarrado = false; // Estado de si el dardo está agarrado

    private void Update()
    {
        // Detecta si se puede recoger o soltar el dardo
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
            // Actualiza la posición del dardo para que se mueva con el personaje
            dardo.position = dardoHoldPosition.position;
        }

        // Otros métodos de movimiento y actualización
    }

    private void IntentarAgarrarDardo()
    {
        // Detecta si el personaje está cerca del dardo
        if (Vector3.Distance(transform.position, dardo.position) <= dardoPickupDistance)
        {
            dardoAgarrado = true;
            dardo.SetParent(dardoHoldPosition); // Opcional: Hace que el dardo se mueva con el personaje
            dardo.localPosition = Vector3.zero; // Coloca el dardo en la posición de "agarre"
        }
    }

    private void SoltarDardo()
    {
        dardoAgarrado = false;
        dardo.SetParent(null); // Suelta el dardo para que quede en el mundo
        // Opcional: Puedes añadir física o dejar el dardo en una posición fija
    }
}
