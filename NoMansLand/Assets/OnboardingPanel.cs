using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnboardingPanel : MonoBehaviour
{
    public List<PlayerInput> inputManagers;
    public Timer timer; 
    // Start is called before the first frame update
    void Start()
    {
        foreach(PlayerInput manager in inputManagers)
        {
            manager.DeactivateInput();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        foreach (PlayerInput manager in inputManagers)
        {
            manager.ActivateInput();
        }

        this.gameObject.SetActive(false);
        timer.StartTimer();
    }
}
