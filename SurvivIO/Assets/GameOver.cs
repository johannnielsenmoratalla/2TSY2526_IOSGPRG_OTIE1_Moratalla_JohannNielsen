using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public void Setup()
    {
        Debug.Log("gameover");
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {

    }
}
