using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    [Tooltip("Drag in the text to be shown when the game is paused.")]
    [SerializeField] GameObject pauseUI;
    [SerializeField] private bool gameIsPaused;

    void Update () {
        OnUserInput();
        PauseGame();
	}

    
    private void OnUserInput()
    {
        //Changes bool on user input.
        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (gameIsPaused)
            {
                case (true):
                    gameIsPaused = false;
                    break;
                case (false):
                    gameIsPaused = true;
                    break;
            }
        }
    }
    
    
    private void PauseGame()
    {
        //Pauses and unpases based on bool.
        //Activates and deactivates the "Paused" text.
        switch (gameIsPaused)
        {
            case (true):
                Time.timeScale = 0;
                pauseUI.SetActive(true);
                break;
            case (false):
                Time.timeScale = 1;
                pauseUI.SetActive(false);
                break;
        }
    }
}
