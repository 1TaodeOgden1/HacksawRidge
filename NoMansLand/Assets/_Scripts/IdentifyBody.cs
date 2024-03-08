using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyBody : MonoBehaviour
{
    [Header("Contents")]
    public Sprite sprite;
    public string bodyName;
    public string rank;
    public string DOB;
    public string backgroundStory;

    [Header("Logic")]
    public GameObject contents;
    public bool identified = false;

    [Header("Display")]
    public Image headImage;
    public TMP_Text bodyNameTxt;
    public TMP_Text rankTxt;
    public TMP_Text DOBTxt;
    public TMP_Text backgroundStoryTxt;

    private void Start()
    {
        headImage.sprite = sprite;
        bodyNameTxt.text = bodyName;
        rankTxt.text = rank;
        DOBTxt.text = DOB;
        backgroundStoryTxt.text = backgroundStory;

        //HideInfo();
        Invoke("HideInfo", 0.1f);
        CheckOverlap();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            IdentifyManager.Instance.examiningBody = this;
            IdentifyManager.Instance.IdentifyCheck();
            IdentifyManager.Instance.HandleInstructions();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            HideInfo();
            if (IdentifyManager.Instance.examiningBody != this) return;
            IdentifyManager.Instance.examiningBody = null;
            IdentifyManager.Instance.IdentifyCheck();
            IdentifyManager.Instance.HandleInstructions();
        }
    }
    public void ShowInfo() => contents.gameObject.SetActive(true);
    public void HideInfo() => contents.gameObject.SetActive(false);
    public void CheckOverlap()
    {
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        Vector3 p1 = transform.position + col.center + transform.forward * -col.height * 0.5f;
        Vector3 p2 = p1 + transform.forward * col.height;

        Collider[] overlaps = Physics.OverlapCapsule(p1, p2, col.radius, Physics.AllLayers, QueryTriggerInteraction.UseGlobal);
        if (overlaps.Length == 0) return;
        print("capsule hit something");
        for (int i = 0; i < overlaps.Length; i++)
        {
            if (!overlaps[i].transform.CompareTag("Body")) continue;
            if (overlaps[i].gameObject == gameObject) continue;
            //Debug.Log(transform.name + " collides with " + overlaps[i].name);
            Vector3 moveDir = (transform.position - overlaps[i].transform.position).normalized;
            moveDir.y = 0;
            transform.position += moveDir * col.radius;
        }
    }
    public void GraspPlayer()
    {
        Transform dragTransform = GameObject.Find("DragPosition").transform;
        transform.position = dragTransform.position;
        transform.rotation = dragTransform.rotation;
        transform.parent = dragTransform.parent;
    }
    public void DitchPlayer()
    {
        transform.position += transform.parent.right * 2f;
        transform.parent = transform.parent.parent;
        HideInfo();
        snapToGround();
        CheckOverlap();
    }
    private void snapToGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            transform.position = hit.point;
        }
    }
}
