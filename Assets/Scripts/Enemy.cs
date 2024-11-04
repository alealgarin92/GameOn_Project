using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;
    private EnemyBehaviour enemy;
    
    private void Awake()
    {
        health = maxHealth;  
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        //if (health <= 30)
        //{
        //    enemy.Flee();
            
        //}
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
