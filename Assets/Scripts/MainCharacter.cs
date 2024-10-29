using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 mouseSensitivity;
    [SerializeField] private Transform raycastOrigin;

    [SerializeField] private float maxHealth;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float health;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCheckDistance;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Vector3 startingRotation;

    [SerializeField] private Animator characterAnimator;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;


    private Camera camara;
    private float shootingCooldown;

    private void Awake()
    {
        health = maxHealth;

        //Linea que nos ayuda a boquear el puntero una vez presionado play
        Cursor.lockState = CursorLockMode.Locked;
        camara = Camera.main;
    }


    private void Update()
    {
        //Mover utilizando WASD

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movementDir = new Vector2(horizontal, vertical);

        
        

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetKey("w"))
        {
            StartWalking();
        }
        else
        {
            Idle();
        }

        movementDir = movementDir.normalized;
        Move(movementDir);

        LookAtMouseDirection();

    }

    private void LookAtMouseDirection()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * mouseSensitivity.x, 0);
        }

        if (vertical != 0) 
        {
            Vector3 rotation = camara.transform.localEulerAngles;
            rotation.x = (rotation.x - vertical * mouseSensitivity.y + 360) % 360;
            if (rotation.x > 80 && rotation.x < 180) {rotation.x = 80;} else
            if (rotation.x < 280 && rotation.x > 180) { rotation.x = 280;}

            camara.transform.localEulerAngles = rotation;
        }
    }

    private void Move(Vector2 movementDir)
    {
        //Vector3 movement = new Vector3(movementDir.x, 0,movementDir.y);
        //Agarro el vector derecha del jugador y lo multiplico por x
        Vector3 right = transform.right * movementDir.x;
        //Agarro el vector adelante del jugador y lo multiplico por y
        Vector3 forward = transform.forward * movementDir.y;
        //SUmo ambos vectores
        Vector3 direction = right + forward;


        transform.position += direction * movementSpeed * Time.deltaTime;
    }






    private void FixedUpdate()
    {

    }

    private void Jump()
    {
        //No puede saltar si el piso esta muy lejos
        bool hitGround =
            UnityEngine.Physics.Raycast(raycastOrigin.position, Vector3.down, jumpCheckDistance, groundLayer);

        if (hitGround)
        {
            Vector3 direction = Vector3.up; // Lo mismo que escribir new vector3(0,1,0);
            rb.AddForce(direction * jumpForce, ForceMode.Impulse);
            PlayJumpSound();
        }

    }
   

    private void StartWalking()
    {
        characterAnimator.SetBool("isWalking", true);
    }

    private void StartRuning()
    {
        characterAnimator.SetBool("isRunning", true);
    }

    private void Idle()
    {
        characterAnimator.SetBool("isWalking", false);
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.down * jumpCheckDistance);
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(audioClip);
    }

}
