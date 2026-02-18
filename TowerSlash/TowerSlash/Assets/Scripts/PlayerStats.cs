using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public int playerHP = 5;
    public int playerScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        playerHP = PlayerHP.instance.GetHP();
    }
    private void Update()
    {
        if (healthText != null && scoreText != null )
        {
            healthText.text = "HP: " + playerHP;
            scoreText.text = "Score: " + playerScore;
        }
    }
    public void PlusScore()
    {
        if (GameManager.instance.GetIsAlive() == true)
        {
            playerScore += 1;
        }

    }

    public void IncreaseHealth()
    {
        playerHP += 1;
    }
    public void PlayerHealthCheck()
    {
        if (playerHP <= 0)
        {
            GameManager.instance.PlayerDeath();
        }
    }
    public void DecreaseHealth()
    {
        if (GameManager.instance.GetIsAlive() == true)
        {
            playerHP -= 1;
        }
    }

}
