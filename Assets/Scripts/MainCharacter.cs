using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform raycastOrigin;

    [SerializeField] private float maxHealth;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float health;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCheckDistance;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Vector3 startingRotation;

    [SerializeField] private Animator mouseAnimator;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private Camera camera; // Referencia a la c�mara



    private float shootingCooldown;

    private void Awake()
    {
        health = maxHealth;
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

        movementDir = movementDir.normalized;
        Move(movementDir);

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
        mouseAnimator.SetBool("isWalking", true);
    }

    private void Idle()
    {
        mouseAnimator.SetBool("isWalking", false);
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
