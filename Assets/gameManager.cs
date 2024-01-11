using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{

    [SerializeField] private TMP_Text paddle1ScoreText;
    [SerializeField] private TMP_Text paddle2ScoreText;

    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    private int paddle1Score;
    private int paddle2Score;

    private static gameManager instance;

    public static gameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<gameManager>();
            }
            return instance;
        }
    }

    public void paddle1Scored()
    {
        paddle1Score++;
        paddle1ScoreText.text = paddle1Score.ToString();
    }

    public void paddle2Scored()
    {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();
    }

    public void restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x,0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
