using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject explosioneffect;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;


        if (currentHealth <= 80)
        {
            anim.SetTrigger("1");
        }
        if (currentHealth <= 50)
        {
            anim.SetTrigger("2");
        }
        if (currentHealth <= 20)
        {
            anim.SetTrigger("3");
        }

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
        Destroy(obj,1);
    }
}
