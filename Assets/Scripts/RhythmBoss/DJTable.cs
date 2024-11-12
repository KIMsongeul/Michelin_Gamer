using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJTable : MonoBehaviour
{
    private float upMax = 0f;
    private float downMax = -2.0f;
    private float currentPosition;
    private float direction = 3.0f;

    private void Start()
    {
        currentPosition = transform.position.y;
    }

    private void Update()
    {
        currentPosition += Time.deltaTime * direction;
        if (currentPosition >= upMax)
        {
            direction *= -1;
            currentPosition = upMax;
        }
        else if (currentPosition <= downMax)
        {
            direction *= -1;
            currentPosition = downMax;
        }

        transform.position = new Vector3(0, currentPosition, 0);
    }
}
