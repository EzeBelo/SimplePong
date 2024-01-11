using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;

    void Update()
    {
        float movement;

        if (isPaddle1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        Vector2 paddlePos = transform.position;

        paddlePos.y = Mathf.Clamp(paddlePos.y + movement * speed * Time.deltaTime,-3.95f,3.95f);
        transform.position = paddlePos;

    }
}
