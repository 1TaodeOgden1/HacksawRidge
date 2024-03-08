using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject optionsPanel; 
    public bool isPaused = false; 

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
        optionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
   
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        optionsPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        pauseScreen.SetActive(true);
    }


    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");

    }

    
}
