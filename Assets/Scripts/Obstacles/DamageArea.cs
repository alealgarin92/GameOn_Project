using UnityEngine;
using System.Collections;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    [SerializeField] private AudioClip sonidodolor;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerstay(Collider other)
    {

        Damage(other.gameObject);
    }
    private void Damage(GameObject target)
    {
        MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
        if (mainCharacter != null)
        {
            mainCharacter.TakeDamage(damageAmount * Time.fixedDeltaTime);
            Dolorpersonaje();
        }
    }
    public void Dolorpersonaje()
    {
        audioSource.PlayOneShot(sonidodolor);
    }
}
