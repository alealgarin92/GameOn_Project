using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{
    //Opciones de niveles
    public void CambiarNivel(int nroNivel)
    {
        SceneManager.LoadScene(nroNivel);
    }
}
