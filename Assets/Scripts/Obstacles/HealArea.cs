using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour
{
    [SerializeField] private float healAmount;

    private void OnTriggerStay(Collider other)
    {
        
        Heal(other.gameObject);
    }
    private void Heal(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            mainCharacter.Heal(healAmount * Time.fixedDeltaTime);
        }
    }
    
}
