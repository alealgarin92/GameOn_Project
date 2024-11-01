using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private MainCharacter player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float lerpspeed;
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;



    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            camera2.gameObject.SetActive(true);
            camera1.gameObject.SetActive(false);
        }
    }
}