using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public Image energyBar;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public int playerHP = 5;
    public int playerScore = 0;

    public float maxEnergy = 100f;
    public float currentEnergy = 0.0f;
    public float fillSpeed = 0.5f;
    public bool boosted = false;
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
        currentEnergy = 100.0f;
    }
    private void Update()
    {
        if (healthText != null && scoreText != null && energyBar != null)
        {
            healthText.text = "HP: " + playerHP;
            scoreText.text = "Score: " + playerScore;
            energyBar.fillAmount = currentEnergy / maxEnergy;
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
    public void IncreaseEnergy(float increaseAmount)
    {
        currentEnergy += increaseAmount;

        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);
        energyBar.fillAmount = currentEnergy / maxEnergy;
    }
    public void BoostButtonPressed()
    {
        if (currentEnergy <= 100.0f)
        {
            GameManager.instance.Boosted();
            Debug.Log("Pressed");
            currentEnergy = 0;
        }
    }
}
