using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private ScoreManager scoreManager;
    private BallController ballController;
    private GameManager gameManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        ballController = FindObjectOfType<BallController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (!gameObject.CompareTag("LeftScorePaddle"))
            {
                scoreManager.AddLeftScore();
                ballController.isLeftPaddleTurn = false;
            }
            else
            {
                scoreManager.AddRightScore();
                ballController.isLeftPaddleTurn = true;
            }

            if (!gameManager.isGameEnd) StartCoroutine(ballController.LaunchBall());
        }
    }
}
