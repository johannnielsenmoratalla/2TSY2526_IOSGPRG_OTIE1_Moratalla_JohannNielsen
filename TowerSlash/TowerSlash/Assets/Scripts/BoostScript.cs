using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostScript : MonoBehaviour
{
    public void IsPressed()
    {
        PlayerStats.instance.BoostButtonPressed();
        Debug.Log("BOOST");
    }
}