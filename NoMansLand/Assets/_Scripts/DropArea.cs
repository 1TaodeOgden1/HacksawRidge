using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public int score = 0;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Body")){
            Destroy(collision.gameObject);
            score++;
        }
    }
}
