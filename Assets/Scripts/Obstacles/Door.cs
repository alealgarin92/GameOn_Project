using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    private void OnTriggerStay(Collider other)
    {
        FrontDoor(other.gameObject);
    }

    private void FrontDoor(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            if (Input.GetKey(KeyCode.F))
            {
                OpenDoor();
            }
            if (Input.GetKey(KeyCode.G))
            {
                CloseDoor();
            }
        }
    }

    [ContextMenu("OpenDoor")] 
    private void OpenDoor()
    {
        doorAnimator.SetBool("isOpening", true);
        doorAnimator.SetBool("isClosing", false);

    }

    [ContextMenu("CloseDoor")]
    private void CloseDoor()
    {
        doorAnimator.SetBool("isOpening", false);
        doorAnimator.SetBool("isClosing", true);
    }
}

