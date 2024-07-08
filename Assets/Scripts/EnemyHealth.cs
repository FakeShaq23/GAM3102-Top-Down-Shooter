using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image fill;
    Animator anim;
    public int moneyToGive;

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

        UpdateHealthBar();

        if(currentHealth <= 0)
        {
            Die();
            GameManager.instance.money += moneyToGive;
            SaveManager.instance.activeSave.currentMoney = GameManager.instance.money;
        }
    }

    public void UpdateHealthBar()
    {
        float hpBar = currentHealth/maxHealth;
        fill.fillAmount = hpBar;
        if(currentHealth <= 0)
        {
            fill.fillAmount = 0;
        }
    }

    public void Die()
    {
        anim.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,3);
    }
}
