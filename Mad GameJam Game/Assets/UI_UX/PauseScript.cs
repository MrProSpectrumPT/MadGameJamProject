using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        if (Time.timeScale == 1)
        {
            gameIsPaused = false;
            PauseMenuCanvas.SetActive(false);
        }
    }

    void PauseGame()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            PauseMenuCanvas.SetActive(true);
        }
    }
}
