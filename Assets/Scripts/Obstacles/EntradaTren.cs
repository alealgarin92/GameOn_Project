using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnrtadaTren : MonoBehaviour
{
    [SerializeField] private Animator animatorTren;

    public void Entratren()
    {
        animatorTren.SetBool("EntraTren", true);
    }

    public void Closedoor()
    {
        animatorTren.SetBool("EntraTren", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        Esperatren(other.gameObject);
    }

    public void Esperatren(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            Destroy(gameObject);
            Entratren();
        }
    }
}
