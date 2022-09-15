using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private ScoreManager scoreManager;
    private BallController ballController;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        ballController = FindObjectOfType<BallController>();
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

            if (!GameManager.Instance.isGameEnd) StartCoroutine(ballController.LaunchBall());
        }
    }
}
