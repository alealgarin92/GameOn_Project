using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    
    
    private void OnTriggerStay(Collider other)
    {
        FrontDoor(other.gameObject);
    }

    private void FrontDoor(GameObject target)
    {
        MainCharacter player = target.GetComponent<MainCharacter>();
        if (player != null)
        {
            PasarNivelSubte();
        }
    }

    
    public void PasarNivelSubte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
