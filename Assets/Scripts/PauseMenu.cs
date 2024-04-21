using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas scoreCanvas;

    void Start()
    {
        pauseCanvas.enabled = false;
        scoreCanvas.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        pauseCanvas.enabled = !pauseCanvas.enabled;
        scoreCanvas.enabled = !scoreCanvas.enabled;

        if (pauseCanvas.enabled)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        pauseCanvas.enabled = false;
        scoreCanvas.enabled = true;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
