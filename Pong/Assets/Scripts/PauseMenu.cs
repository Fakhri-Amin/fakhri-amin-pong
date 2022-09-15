using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    private bool toggle = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
            ShowOptionMenu();
        }
    }

    private void ShowOptionMenu()
    {
        if (pauseCanvas == null) { return; }

        if (toggle)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        FindObjectOfType<MusicManager>().PlayPauseWhistleSFX();
        FindObjectOfType<MusicManager>().TurnTheVolume(0.5f);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        FindObjectOfType<MusicManager>().PlayPauseWhistleSFX();
        FindObjectOfType<MusicManager>().TurnTheVolume(1);
    }
}
