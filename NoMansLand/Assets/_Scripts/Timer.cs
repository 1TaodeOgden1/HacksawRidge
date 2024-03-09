using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining; 
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText; 

    public GameObject finishedScreen;
    public DropArea dropArea;

    private void Start()
    {
        // Starts the timer paused
        timerIsRunning = false;
    }

    /*timer code copied from:
     https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
    */
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {

                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                OnTimeEnd();
            }
        }

        DisplayTime(timeRemaining);
    }

    void OnTimeEnd()
    {
        GetComponent<RescueTracker>().AddRescueData(new RescueData(dropArea.broSaved, dropArea.leftEarly, dropArea.namesSaved));
        finishedScreen.SetActive(true);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);


        if(seconds < 10)
        {
            timerText.text = $"{minutes}:0{seconds}";
        }
        else
        {
            timerText.text = $"{minutes}:{seconds}";
        }
        
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }
}
