using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP instance;
    public int playerHp = 0;
    public bool isCharacterSpeed = false;

    public void Start()
    {
        GetHP();
    }
    public void Awake()
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
    public int GetHP()
    {
        return playerHp;
    }
    public void SetHP(int setThisHP)
    {
        playerHp = setThisHP;
    }
    public bool GetIsCharacterSpeed()
    {
        return isCharacterSpeed;
    }
    public void SetIsCharacterSpeed(bool setThisSpeed)
    {
        isCharacterSpeed = setThisSpeed;
    }
}
