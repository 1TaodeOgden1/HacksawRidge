using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVisible : MonoBehaviour
{
    public List<GameObject> enableOnUIElements = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool enableCursor = false;
        foreach(GameObject uiElement in enableOnUIElements)
        {
            if (uiElement.activeSelf)
            {
                enableCursor = true;
            }
        }

        Cursor.visible = enableCursor;
    }
}
