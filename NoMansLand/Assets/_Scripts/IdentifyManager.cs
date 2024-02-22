using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyManager : MonoBehaviour
{
    public TMP_Text identifyText;
    public Slider identifySlider;
    public Image infoImage;

    public List<IdentifyBody> bodies = new List<IdentifyBody>();

    #region singleton
    private static IdentifyManager _instance;
    public static IdentifyManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }
    #endregion

    private void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Body");
        bodies.Clear();
        foreach (GameObject go in gos)
        {
            bodies.Add(go.GetComponent<IdentifyBody>());
        }
    }
    
}
