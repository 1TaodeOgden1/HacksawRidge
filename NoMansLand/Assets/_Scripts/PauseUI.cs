using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public PlayerPause pauseManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        pauseManager.isPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0; 
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");

    }

    
}
