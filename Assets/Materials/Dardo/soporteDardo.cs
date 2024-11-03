using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soporte_dardo : MonoBehaviour
{
    public Transform dardoPunto;
    public GameObject dardoPrefab;
    public float dardoSpeed = 10;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var dardo = Instantiate(dardoPrefab, dardoPunto.position, dardoPunto.rotation);
            dardo.GetComponent<Rigidbody>().velocity = dardoPunto.forward * dardoSpeed;
        }
    }
}