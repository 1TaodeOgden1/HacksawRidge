using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyManager : MonoBehaviour
{
    public TMP_Text instructionMessage;
    public Slider identifySlider;
    public Image infoImage;

    public List<IdentifyBody> bodies = new List<IdentifyBody>();
    public IdentifyBody currentBody;
    public float totalTime = 1f;

    [Header("private fields")]
    [SerializeField] private float timer = 0;
    [SerializeField] private bool identifyFinished = false;
    
    #region singleton
    private static IdentifyManager _instance;
    public static IdentifyManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }
    #endregion

    public void IdentifyReset()
    {
        timer = 0;
        identifyFinished = false;
        instructionMessage.gameObject.SetActive(true);
        infoImage.gameObject.SetActive(false);
        currentBody = null;
    }
    public void IdentifyFinished()
    {
        timer = totalTime;
        identifyFinished = true;
        instructionMessage.gameObject.SetActive(false);
        infoImage.gameObject.SetActive(true);

    }
    private void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Body");
        bodies.Clear();
        foreach (GameObject go in gos)
        {
            bodies.Add(go.GetComponent<IdentifyBody>());
        }

        IdentifyReset();
    }

    private void Update()
    {
        identifySlider.value = timer/totalTime;
        if (identifySlider.value < 0.01f || identifySlider.value > 0.99f) identifySlider.gameObject.SetActive(false);
        else identifySlider.gameObject.SetActive(true);

        if (Input.GetKey(KeyCode.E) && !identifyFinished)
        {
            timer += Time.deltaTime;

            if (timer > totalTime)
            {
                IdentifyFinished();
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (identifyFinished)
            {
                IdentifyFinished();
            }
            else
            {
                IdentifyReset();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IdentifyReset();
        }
    }

    
}
