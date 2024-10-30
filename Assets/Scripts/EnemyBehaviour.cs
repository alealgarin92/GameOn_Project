using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyState
{
    public EnemyStates currentState;
}

public enum EnemyStates
{
    Confused = 0,
    Fleeing = 1,
    Pursuit = 2,
    Stay = 3,
    Dead = 4,
    LookAtPlayer
}
public class EnemyBehaviour : MonoBehaviour
{
    //private bool isPlayerInSight;
    //private float currentHealt;
    //private bool isConfused;

    [SerializeField] private EnemyStates startingtState;
    [SerializeField] private MainCharacter player;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float pursuitThreshold;
    [SerializeField] private float rotationSpeed;

    
    void Update()
    {
        CheckStateUpdate();
        //Todo
        switch (startingtState)
        {
            case EnemyStates.Confused:
                RandomMovement();
                break;
            case EnemyStates.Fleeing:
                Flee();
                break;
            case EnemyStates.Pursuit:
                Pursuit();
                break;
            case EnemyStates.Stay:
                Stay();
                break;
            case EnemyStates.LookAtPlayer:
                LookRotationQuaternion();
                break;
            default:
                Stay();
                break;
        }
    }

    //Modo mas simple de mirar al jugador 
    private void LookAtPlayer()
    {
        transform.LookAt(player.transform.position);
    }

    //Modo alternativo para mirar al jugador
    private void LookRotationQuaternion()
    {
        var newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation,Time.deltaTime * rotationSpeed);
    }
    private void CheckStateUpdate()
    {
        //Si el player esta muy lejos, me quedo quieto.
        var diff = transform.position - player.transform.position;
        var distance = diff.magnitude;

        if(distance > pursuitThreshold )
        {
            if(startingtState == EnemyStates.Pursuit)
            {
                startingtState = EnemyStates.Stay;
            }
        }
        else
        {
            startingtState = EnemyStates.Pursuit;
        }
    }

    private void Stay()
    {

    }

    private void Pursuit()
    {
        LookRotationQuaternion();
        
        transform.position += transform.forward * (Time.deltaTime * movementSpeed);
    }

    private void Flee()
    {
        Vector3 a = player.transform.position;
        Vector3 b = transform.position;
        Vector3 diff = (b - a).normalized;


        transform.position += diff * (Time.deltaTime * movementSpeed);
    }
     
    private void RandomMovement()
    {

    }
}
