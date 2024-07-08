using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject explosioneffect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Explosion();
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Explosion()
    {
        GameObject obj = Instantiate(explosioneffect, transform.position, transform.rotation);
        Destroy(obj, 1);
    }
}