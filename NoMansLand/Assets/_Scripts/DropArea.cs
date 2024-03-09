using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DropArea : MonoBehaviour
{
    public List<string> namesSaved;
    public List<Sprite> faces_of_the_Lost;
    public TextMeshProUGUI objectiveText;
    public GameObject homePrompt;

    //Return to Base Component; enables the player to end the game early
    private ReturnToBase rtb;
    public string broName = "David";
    public bool broSaved = false;
    public Timer timer;
    public bool leftEarly = false;

    public bool overlapping = false;


    public void Start()
    {
        objectiveText = GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
        homePrompt.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        overlapping = true;

        if (collision.transform.CompareTag("Body")){


            string bodyName = collision.gameObject.GetComponent<IdentifyBody>().bodyName;
            Sprite bodyFace = collision.gameObject.GetComponent<IdentifyBody>().headImage.sprite;
            faces_of_the_Lost.Remove(bodyFace);
            namesSaved.Add(bodyName);

            if(bodyName == broName)
            {
                broSaved = true;
                objectiveText.text = "Return home?";
            }

            Destroy(collision.gameObject);

        }

        if (broSaved)
        {
            homePrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        overlapping = false;
        homePrompt.SetActive(false);
    }

    public void OnLeave(InputValue value)
    {
        Debug.Log("Hi");
        if (broSaved && overlapping)
        {
            leftEarly = true;
            timer.timeRemaining = 0;
        }

    }
}
