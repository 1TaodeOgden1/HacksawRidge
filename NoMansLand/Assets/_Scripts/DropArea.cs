using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Body")){
            Destroy(collision.gameObject);
        }
    }
}
