using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentBullet : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private float damagePerTick;

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damagePerTick * Time.fixedDeltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            //Destruyo la bala  
            Destroy(gameObject);
        }
        Move();
    }

    private void Move()
    {
        transform.position += movementSpeed * transform.forward * Time.deltaTime;
    }
}
