using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parlantes : MonoBehaviour
{
    [SerializeField] private AudioSource parlante; // Asigna el objeto parlante en el Inspector
    private bool parlanteEncendido = false; // Estado del parlante

    private void Update()
    {
        // Llama a la función para encender/apagar el sonido si se presiona la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleParlante();
        }
    }

    private void ToggleParlante()
    {
        if (parlanteEncendido)
        {
            parlante.Stop(); // Apaga el sonido
        }
        else
        {
            parlante.Play(); // Enciende el sonido
        }
        parlanteEncendido = !parlanteEncendido; // Cambia el estado
    }

}
