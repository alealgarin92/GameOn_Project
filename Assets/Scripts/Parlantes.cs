using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parlantes : MonoBehaviour
{
    [SerializeField] private AudioSource parlante; 
    private bool parlanteEncendido = false; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleParlante();
        }
    }

    private void ToggleParlante()
    {
        if (parlanteEncendido)
        {
            parlante.Stop(); 
        }
        else
        {
            parlante.Play(); 
        }
        parlanteEncendido = !parlanteEncendido; 
    }
}
