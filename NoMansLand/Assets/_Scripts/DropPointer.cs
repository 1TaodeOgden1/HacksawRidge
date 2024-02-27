using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPointer : MonoBehaviour
{
    public GameObject dropArea;
    private void Update()
    {
        if (dropArea == null) return;
        transform.LookAt(dropArea.transform.position);
    }
}
