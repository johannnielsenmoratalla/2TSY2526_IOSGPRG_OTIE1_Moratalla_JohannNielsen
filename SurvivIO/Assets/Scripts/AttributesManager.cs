using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public GameOver gameOver;
    
    public PlayerStats playerStats;
    public int health;
    public int attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            PlayerStats ps = GetComponent<PlayerStats>();
            if (ps != null)
            {
                Debug.Log("Player Died");
                gameOver.Setup();
            }
            else
            {
                Destroy(gameObject);
            }
   
        }
    }

    public void DealDamage(GameObject target)
    {
        PlayerStats playerStats = target.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            playerStats.TakeDamage(attack);
        }
    }
}
