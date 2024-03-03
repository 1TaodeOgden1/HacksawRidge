using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Rects update");
        GameObject[] objArray = GameObject.FindGameObjectsWithTag("Body");
        foreach (GameObject obj in objArray)
        {
            Debug.Log(obj.name);
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
        
        for(int i = 0; i < activeContents.Count; i++)
        {
            activeContents[i].TweakOffset(i);
        }
        
    }
}
