using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject leftPlayerWinUI;
    [SerializeField] private GameObject rightPlayerWinUI;

    public bool isGameEnd;

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
    }

    public void DisplayRightPlayerWinUI()
    {
        isGameEnd = true;
        rightPlayerWinUI.SetActive(true);
    }
}
