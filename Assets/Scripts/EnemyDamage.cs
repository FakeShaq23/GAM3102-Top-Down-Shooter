using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth _playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            _playerHealth.TakeDamage(damage);
        }

    }
}
