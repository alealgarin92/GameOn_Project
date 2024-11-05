using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Linterna linterna;
    [SerializeField] private Vector2 mouseSensitivity;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private Transform raycastLanternOrigin;


    [SerializeField] private float maxHealth;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float health;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCheckDistance;
    [SerializeField] private float enemyCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private float damagePerTick;

    [SerializeField] private Vector3 startingRotation;

    [SerializeField] private Animator characterAnimator;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    //Patalla de derrota, victoria y pausa
    [SerializeField] private GameObject pantallaMenuDerrota;

    //Barra de vida
    [SerializeField] private Image barraDeEstres;

    private Linterna instantiatedLantern; // Variable para almacenar la linterna instanciada
    private bool linternaEncendida = false; // Estado de la linterna (encendida/apagada)

    private EnemyBehaviour targetEnemy;
    private Enemy enemy;

    public float saldoSube;

    private new Camera camera;
    private float shootingCooldown;

    private MenuInicial menu;

    private GameObject permanetLantern;

    public int cantSube = 0;
    public int cantLlaves = 0;
    private void Awake()
    {
        health = maxHealth;

        //Linea que nos ayuda a bloquear el puntero una vez presionado play
        Cursor.lockState = CursorLockMode.Locked;
        camera = Camera.main;
        permanetLantern = GameObject.FindGameObjectWithTag("Linterna");

        characterAnimator = GetComponent<Animator>();
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
      
        if (permanetLantern != null)
        {
            linternaEncendida = false;
        }
        else
        {
            FlashLightCreate(); 
        }
        
        if (linternaEncendida)
        {
            FlashLightEnemy();
        }

        MainCharacterMovements();

        movementDir = movementDir.normalized;
        Move(movementDir);

        LookAtMouseDirection();

        barraDeEstres.fillAmount = health / maxHealth;

        //Salir();

    }

    //Los distintos estados del personaje principal y sus animaciones
    private void MainCharacterMovements()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 4;
            StartRuning();

        }
        else if (Input.GetKey(KeyCode.W))
        {
            movementSpeed = 2;
            StartWalking();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementSpeed = 2;
            StartWalkingBack();

        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementSpeed = 2;
            StartWalkingLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementSpeed = 2;
            StartWalkingRight();

        }
        else
        {
            Idle();
        }
    }

    private void LookAtMouseDirection()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        //Movimiento en eje horizontal del mouse 
        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * mouseSensitivity.x, 0);
        }

        //Porcion de funcion que limita el movimiento en eje Vertical
        if (vertical != 0)
        {
            Vector3 rotation = camera.transform.localEulerAngles;
            rotation.x = (rotation.x - vertical * mouseSensitivity.y + 360) % 360;
            if (rotation.x > 80 && rotation.x < 180) { rotation.x = 80; } else
            if (rotation.x < 280 && rotation.x > 180) { rotation.x = 280; }

            camera.transform.localEulerAngles = rotation;
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
        }

    }

    private void FlashLightCreate()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            if (!linternaEncendida)
            {
                // Enciende la linterna
                instantiatedLantern = Instantiate(linterna, raycastLanternOrigin.position, raycastLanternOrigin.rotation);
                instantiatedLantern.transform.SetParent(raycastLanternOrigin);
                FlashLightEnemy();
                linternaEncendida = true;
            }
            else
            {
                // Apaga la linterna si ya est� encendida
                Destroy(instantiatedLantern.gameObject);
                instantiatedLantern = null;
                linternaEncendida = false;
            }
        }
    }

    
    private void FlashLightEnemy()
    {
        // Realiza el Raycast cada frame mientras la linterna esta encendida
        if (Physics.Raycast(raycastLanternOrigin.position, raycastLanternOrigin.forward, out RaycastHit hit, enemyCheckDistance, enemyLayer))
        {
            // Checkea si el objeto con el que choca el rayo tiene el componente Enemy
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Resta vida al enemigo 
                enemy.TakeDamage(damagePerTick * Time.deltaTime);
            }
        }
    }

    //Los estados de las distintas animcaciones
    private void StartWalking()
    {
        characterAnimator.SetBool("isWalking", true);
        characterAnimator.SetBool("isRunning", false);
        characterAnimator.SetBool("isJumping", false);
    }

    private void StartWalkingBack()
    {
        characterAnimator.SetBool("isWalkingBack", true);
    }

    private void StartWalkingRight()
    {
        characterAnimator.SetBool("isWalkingRight", true);
    }

    private void StartWalkingLeft()
    {
        characterAnimator.SetBool("isWalkingLeft", true);
    }
    private void StartRuning()
    {
        characterAnimator.SetBool("isRunning", true);

    }

    private void Idle()
    {
        characterAnimator.SetBool("isWalking", false);
        characterAnimator.SetBool("isRunning", false);
        characterAnimator.SetBool("isWalkingBack", false);
        characterAnimator.SetBool("isWalkingRight", false);
        characterAnimator.SetBool("isWalkingLeft", false);
        characterAnimator.SetBool("isJumping", false);

    }

    private void StartJumping()
    {
        characterAnimator.SetBool("isWalking", true);
    }

    public void Heal(float healAmount)
    {
        if (health < 100)
        {
            health += healAmount;
        }
    }

    //Funcion para visualizar el raycast de salto y el de deteccion de enmigos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.down * jumpCheckDistance);

        Gizmos.DrawLine(raycastLanternOrigin.position, raycastLanternOrigin.position + transform.forward * enemyCheckDistance);
    }


    public void CargaSube(float dinero)
    {
        if (saldoSube < 1000)
        {
            saldoSube += dinero;
        }
    }
    public void ApoyaSube(float restaSaldo)
    {
        if (saldoSube > 500)
        {
            saldoSube -= restaSaldo;

        }
    }

    public void Salir()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //Cargar menu principal
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //Die();
            pantallaMenuDerrota.SetActive(true);
            Time.timeScale = 0;

        }
    }

    /*
    private void Die()
    {
        Destroy(gameObject);
    }
    */
}