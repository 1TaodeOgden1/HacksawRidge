using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
    private int currentPanelIndex = 0;
    public List<GameObject> breakdown_panels;
    public Button quitButton;
    public Button nextButton;
 
    public DropArea dropArea;
    public TextMeshProUGUI saved_container;
    public TextMeshProUGUI bro_checker;
    public GameObject LOA_container; 

    public string[] savedNames;
    public int savedNames_length = 24;

  
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; //stops all update-based movement

        dropArea = GameObject.Find("DropArea").GetComponent<DropArea>();

        ReadDropArea();

        savedNames = new string[savedNames_length];
        
        //populating with blank values; this will help with organizing them into columns later 
        for(int i = 0; i< savedNames_length; i++)
        {
            savedNames[i] = "";
        }


        breakdown_panels[currentPanelIndex].SetActive(true);
        quitButton.interactable = false;
    }


    public void ReadDropArea()
    {
        //Debug.Log("hi");
        //output if the player saved their brother
        if (dropArea.broSaved)
        {
            bro_checker.text = "You found your brother.";
        }
        else
        {
            bro_checker.text = "You did not find your brother.";
        }

        string tempString = "";
        foreach(string name in dropArea.namesSaved)
        {
            tempString += $"{name}\n";
        }
        saved_container.text = tempString;

        Image[] image_slots = LOA_container.GetComponentsInChildren<Image>();

        for(int i = 0; i < dropArea.faces_of_the_Lost.Count; i++)
        {
            image_slots[i].color = Color.white;
            image_slots[i].sprite = dropArea.faces_of_the_Lost[i];
        }

    }

    public void LoadNext()
    {
        if(currentPanelIndex < breakdown_panels.Count - 1)
        {
            breakdown_panels[currentPanelIndex].SetActive(false);
            breakdown_panels[currentPanelIndex + 1].SetActive(true);
        }

        currentPanelIndex++;

        if(currentPanelIndex == breakdown_panels.Count - 1)
        {
            nextButton.interactable = false;
            quitButton.interactable = true;
        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("MainMenu");
    }
}
