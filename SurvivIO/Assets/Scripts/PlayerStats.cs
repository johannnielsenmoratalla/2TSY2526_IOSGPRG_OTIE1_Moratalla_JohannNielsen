using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{

    public AttributesManager playerAtm;

    public float startHealth = 100f;
    public float health;

    public Image healthBar;

    void Start()
    {
        health = startHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (playerAtm != null)
        {
            healthBar.fillAmount = (float)playerAtm.health / startHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        health = Mathf.Clamp(health, 0, startHealth);

        UpdateHealthBar();

        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = health / startHealth;
    }

    void Die()
    {

        //Destroy(gameObject);
    }
}
