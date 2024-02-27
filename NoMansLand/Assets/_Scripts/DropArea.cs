using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Body")){
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Lives saved: " + score.ToString();
        }
    }
}
