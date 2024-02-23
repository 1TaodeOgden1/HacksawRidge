using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyBody : MonoBehaviour
{
    public Sprite sprite;
    public string bodyName;
    public string rank;
    public string DOB;
    public string backgroundStory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            IdentifyManager.Instance.currentBody = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            IdentifyManager.Instance.currentBody = null;
        }
    }
}
