using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float distance = 3f;
    public float height = 6f;

    public GameObject player;

    void Update()
    {
        if (player == null) return;

        // Makes the camera face the same direction as the player from a set distance and height away
        float desiredAngle = player.transform.rotation.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        Vector3 desiredPosition = player.transform.position - (rotation * Vector3.forward * distance) + (Vector3.up * height);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
        transform.LookAt(player.transform.position);
    }
}
