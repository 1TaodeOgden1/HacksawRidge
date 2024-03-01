using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPause : MonoBehaviour
{
    public PauseUI pausePanel;

    public void Start()
    {

    }

    public void OnPause(InputValue value)
    {
        //pause the game; show the pause HUD
        if (!pausePanel.isPaused)
        {
            pausePanel.PauseGame();
        }
        //unpause the game; close the pause HUD
        else
        {
            pausePanel.ResumeGame();
        }
    }


}
