using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public MusicController musicController;
    public GameObject ObjetoMenuPausa;
    public bool pausa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa== false)
            {
                ObjetoMenuPausa.SetActive(true);
                pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;


                if (musicController != null)
                {
                    musicController.PauseLevelMusic();
                }
            }
            else
            {
                Continuar();
            }
        }
    }

    public void Continuar()
    {
        Debug.Log("Continuando juego desde el bot�n");
        ObjetoMenuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (musicController != null)
        {
            musicController.ResumeLevelMusic();
        }
    }
}
