using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyBody : MonoBehaviour
{
    public Sprite infoSprite;

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
