using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image fill;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            PlayerController.instance.Die();
            //Die();
        }
    }

    public void UpdateHealthBar()
    {
        float hpBar = currentHealth / maxHealth;
        fill.fillAmount = hpBar;
        if (currentHealth <= 0)
        {
            fill.fillAmount = 0;
        }
    }
}