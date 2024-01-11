using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
using UnityEngine.WSA;
 */
using TMPro;


public class ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velMultiplier = 1.1f;
    [SerializeField] private Rigidbody2D ballRB;

    [SerializeField] private TMP_Text startMessage;


    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
    }

    private void Reset()
    {
        gameManager.Instance.restart();
        ballRB.velocity = ballRB.velocity * 0f;
        startMessage.enabled = !startMessage.enabled;
    }

    private void Launch()
    {
        float xVel = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVel = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRB.velocity = new Vector2(xVel, yVel) * initialVelocity;
        startMessage.enabled = !startMessage.enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ballRB.velocity *= velMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score1"))
        {
            gameManager.Instance.paddle1Scored();
            Invoke("Reset",1f);
        }
        else
        {
            gameManager.Instance.paddle2Scored();
            Invoke("Reset", 1.5f);
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ballRB.velocity == ballRB.velocity * 0f)
            {
                Launch();

            }
         
        }
    }
}
