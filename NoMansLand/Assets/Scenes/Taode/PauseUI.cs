using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResumeGame()
    {
        this.gameObject.SetActive(false);
    }
    void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");

    }

    
}
