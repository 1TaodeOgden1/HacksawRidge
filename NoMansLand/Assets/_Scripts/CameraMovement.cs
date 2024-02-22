using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 posOffset;
    void Start()
    {
        if (player == null) return;
        posOffset = transform.position - player.transform.position;
    }

    void Update()
    {
        if (player == null) return;
        transform.position = player.transform.position + posOffset;
    }
}
