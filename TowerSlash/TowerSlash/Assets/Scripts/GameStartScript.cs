using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("gameScene");
    }
    public void DefaultCharacter()
    {
        PlayerHP.instance.SetIsCharacterSpeed(false);
        PlayerHP.instance.SetHP(3);
        StartGame();
    }
    public void TankCharacter()
    {
        PlayerHP.instance.SetIsCharacterSpeed(false);
        PlayerHP.instance.SetHP(5);
        StartGame();
    }
    public void SpeedCharacter()
    {
        PlayerHP.instance.SetIsCharacterSpeed(true);
        PlayerHP.instance.SetHP(3);
        StartGame();
    }
}
