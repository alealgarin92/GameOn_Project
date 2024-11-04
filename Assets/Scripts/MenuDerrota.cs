using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{
    [SerializeField] private GameObject pantallaMenuDerrota;

    public void Update()
    {
        if (pantallaMenuDerrota.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }


    //Para reiniciar el nivel
    public void ReiniciarElNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(int nro)
    {
        SceneManager.LoadScene(nro);
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

}
