using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPause : MonoBehaviour
{
    public bool isPaused;
    public GameObject pausePrefab;

    public void Start()
    {
        pausePrefab = GameObject.Find("PauseScreen");
        pausePrefab.SetActive(false);
    }

    public void OnPause(InputValue value)
    {
        if (!isPaused)
        {
            pausePrefab.SetActive(true);
            pausePrefab.GetComponent<PauseUI>().PauseGame();
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }





    }


}
