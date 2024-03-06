using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetection : MonoBehaviour
{
    public string tagName;
    private void FixedUpdate()
    {
        if (RaycastDetect())
        {
            print("Found a body");
        }
    }

    //Raycast direction is the z axis of the gameobject
    public bool RaycastDetect()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.CompareTag(tagName))
            {
                return true; ;
            }
        }
        return false;   
    }
}
