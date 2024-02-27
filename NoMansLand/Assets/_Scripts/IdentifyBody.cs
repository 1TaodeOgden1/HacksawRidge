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
            IdentifyManager.Instance.IdentifyReset();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            IdentifyManager.Instance.currentBody = null;
            IdentifyManager.Instance.IdentifyReset();
        }
    }
    public void GraspPlayer()
    {
        Transform dragTransform = GameObject.Find("DragPosition").transform;
        transform.position = dragTransform.position;
        transform.parent = dragTransform.parent;
    }
}
