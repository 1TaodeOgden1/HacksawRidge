using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyBody : MonoBehaviour
{
    public Image infoImage;

    public float totalTime = 1f;
    [SerializeField] private float timer = 0;
    [SerializeField] private bool identifyFinished = false;

    private void Update()
    {
        IdentifyManager.Instance.identifySlider.value = timer / totalTime;
        if (Input.GetKey(KeyCode.E) && !identifyFinished)
        {
            timer += Time.deltaTime;

            if (timer > totalTime)
            {
                IdentifyFinished();
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (identifyFinished)
            {
                IdentifyFinished();
            }
            else
            {
                ResetIdentify();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetIdentify();
        }

    }

    public void ResetIdentify()
    {
        timer = 0;
        identifyFinished = false;
        infoImage.gameObject.SetActive(false);
    }
    public void IdentifyFinished()
    {
        timer = 0;
        identifyFinished = true;
        infoImage.gameObject.SetActive(true);
        
    }
}
