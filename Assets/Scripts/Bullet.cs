using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth _enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            _enemyHealth.TakeDamage(damage);
        }

        if (collision.gameObject.GetComponent<CarHealth>() != null)
        {
            CarHealth _carHealth = collision.gameObject.GetComponent<CarHealth>();
            _carHealth.TakeDamage(damage);
        }

        if (collision.gameObject.GetComponent<Barrel>() != null)
        {
            Barrel _barrelHealth = collision.gameObject.GetComponent<Barrel>();
            _barrelHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
