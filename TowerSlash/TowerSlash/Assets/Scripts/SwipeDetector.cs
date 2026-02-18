using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public GameObject _swipeDirection;

    private void Update()
    {
        _itemDirection _localSwipe = _swipeDirection.gameObject.GetComponent<TouchInputs>()._swipeDirections;
        Debug.Log("Swipe: " + _localSwipe);
    }
}