using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    
    
    [SerializeField] private Animator doorAnimator;

    private void OnTriggerStay(Collider other)
    {
        FrontDoor(other.gameObject);
    }

    private void FrontDoor(GameObject target)
    {
        MainCharacter player = target.GetComponent<MainCharacter>();
        if (player != null)
        {
            if (Input.GetKey(KeyCode.F) && player.cantSube >=1 && player.cantLlaves >= 1)
            {
                PasarNivelSubte();
            }
        }
    }

    
    public void PasarNivelSubte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
