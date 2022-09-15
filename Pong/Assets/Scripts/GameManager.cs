using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject leftPlayerWinUI;
    [SerializeField] private GameObject rightPlayerWinUI;
    [SerializeField] private GameObject goalCanvas;

    public bool isGameEnd;

    private TMP_Text goalText;
    private bool hasStarted;



    private void Awake()
    {
        Time.timeScale = 1;

        Instance = this;

        goalText = goalCanvas.GetComponentInChildren<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayLeftPlayerWinUI()
    {
        isGameEnd = true;
        leftPlayerWinUI.SetActive(true);
        MusicManager.Instance.PlayGameEndWhistleSFX();
    }

    public void DisplayRightPlayerWinUI()
    {
        isGameEnd = true;
        rightPlayerWinUI.SetActive(true);
        MusicManager.Instance.PlayGameEndWhistleSFX();
    }

    public void DisplayGoalText()
    {
        StartCoroutine(DisplayTime());
    }

    IEnumerator DisplayTime()
    {
        if (!hasStarted)
        {
            goalText.text = "START!!";
            hasStarted = true;
        }
        else
        {
            goalText.text = "GOAL!!";
        }
        goalCanvas.SetActive(true);
        MusicManager.Instance.PlayWhistleSFX();
        yield return new WaitForSeconds(2.1f);
        goalCanvas.SetActive(false);

    }
}
