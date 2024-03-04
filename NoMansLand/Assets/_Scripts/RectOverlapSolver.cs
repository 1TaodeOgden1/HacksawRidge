using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RectOverlapSolver : MonoBehaviour
{
    public List<WorldUIToCam> contents = new List<WorldUIToCam>();
    private List<WorldUIToCam> activeContents = new List<WorldUIToCam>();

    #region singleton
    private static RectOverlapSolver _instance;
    public static RectOverlapSolver Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }
    #endregion

    private void Start()
    {
        UpdateContents();
    }
    public void UpdateContents()
    {
        contents.Clear();
        GameObject[] objArray = GameObject.FindGameObjectsWithTag("Body");
        foreach (GameObject obj in objArray)
        {
            if (obj.GetComponentInChildren<WorldUIToCam>() == null) continue;
            contents.Add(obj.GetComponentInChildren<WorldUIToCam>());
        }
    }

    public void UpdateActiveContents()
    {
        Debug.Log("Active Contents");
        List<WorldUIToCam> tempContents = new List<WorldUIToCam>();
        foreach (WorldUIToCam c in contents)
        {
            if (c.gameObject.activeSelf)
            {
                tempContents.Add(c);
                Debug.Log(c.gameObject.name);
            }
        }
        activeContents = tempContents;
    }
    private void Update()
    {
        if (activeContents.Count == 0) return;
        if (activeContents.Count <= 1)
        {
            activeContents[0].RestoreOffset();
            return;
        }

        bool haveDraggingBody = false;
        int tempIndex = -1;
        
        for (int i = 0; i < activeContents.Count; i++)
        {
            if (activeContents[i].GetComponentInParent<IdentifyBody>() == null) continue;
            else
            {
                if (activeContents[i].GetComponentInParent<IdentifyBody>() == IdentifyManager.Instance.draggingBody)
                {
                    haveDraggingBody = true;
                    tempIndex = i; 
                    break;
                }
            }
        }

        if (haveDraggingBody)
        {
            for (int i = 0; i < activeContents.Count; i++)
            {
                if(i != tempIndex)
                {
                    activeContents[i].TweakOffset(1);
                }
            }
        }
        else
        {
            for (int i = 0; i < activeContents.Count; i++)
            {
                activeContents[i].TweakOffset(i);
            }
        }        
    }
}
