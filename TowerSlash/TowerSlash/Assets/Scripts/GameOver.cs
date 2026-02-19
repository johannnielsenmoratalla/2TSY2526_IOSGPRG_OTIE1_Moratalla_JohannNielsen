using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI retryText;


    public void Retry()
    {
        SceneManager.LoadScene("Start");
    }
}
