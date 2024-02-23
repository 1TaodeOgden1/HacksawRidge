using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private float movementSpeed = 0.5f;

    private Vector2 movement = Vector2.zero;

    // Update is called once per frame
    void Update()
    {

        if(movement != Vector2.zero)
        {
            m_Animator.ResetTrigger("Stop");

            if(movement.y > 0)
            {
                m_Animator.ResetTrigger("CrawlBack");
                m_Animator.SetTrigger("Crawl");
            } else
            {
                m_Animator.ResetTrigger("Crawl");
                m_Animator.SetTrigger("CrawlBack");
            }
        }
        else
        {
            m_Animator.ResetTrigger("Crawl");
            m_Animator.ResetTrigger("CrawlBack");
            m_Animator.SetTrigger("Stop");
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement.x, 0, movement.y) * movementSpeed * Time.deltaTime;
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
