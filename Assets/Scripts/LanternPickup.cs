using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternPickup : MonoBehaviour
{
    [SerializeField] private Linterna linterna;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        var colliderGameObject = other.gameObject;
        //Necesito chequear la tag/label/etiqueta de el gameobject

        MainCharacter player = colliderGameObject.GetComponent<MainCharacter>();

        if (player != null ) //Tiene el componente player
        {
            if (Input.GetKey(KeyCode.F) && linterna != null)
            {
                linterna.Desapear();
            }
                  
        } 
    }
}
