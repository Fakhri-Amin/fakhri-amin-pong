using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text leftScoreText;
    [SerializeField] private TMP_Text rightScoreText;

    private float leftScore;
    private float rightScore;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        leftScoreText.text = "0";
        rightScoreText.text = "0";
    }

    public void AddLeftScore()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();

        if (leftScore >= 5)
        {
            gameManager.DisplayLeftPlayerWinUI();
        }
    }

    public void AddRightScore()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();

        if (rightScore >= 5)
        {
            gameManager.DisplayRightPlayerWinUI();
        }
    }
}
