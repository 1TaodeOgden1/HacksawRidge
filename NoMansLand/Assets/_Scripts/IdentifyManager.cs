using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyManager : MonoBehaviour
{
    public TMP_Text instructionMessage;
    public Slider identifySlider;

    [Header("contents")]
    public GameObject contents;
    public TMP_Text bodyName;
    public TMP_Text rank;
    public TMP_Text DOB;
    public TMP_Text backgroundStory;
    public Image sprite;

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
    private void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Body");
        bodies.Clear();
        foreach (GameObject go in gos)
        {
            bodies.Add(go.GetComponent<IdentifyBody>());
        }

        IdentifyReset();
        identifySlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (currentBody != null)
        {
            handleInputs();
            handleInstruction();
        }
        else
        {
            instructionMessage.gameObject.SetActive(false);
        }
        
    }
    private void handleInputs()
    {
        if (Input.GetKey(KeyCode.E) && !identifyFinished)
        {
            timer += Time.deltaTime;
            if (timer > totalTime) IdentifyFinished();
        }

        if (Input.GetKeyUp(KeyCode.E) && !identifyFinished) IdentifyReset();

        if (Input.GetKeyDown(KeyCode.Q)) IdentifyReset();
    }
    private void handleInstruction()
    {
        //instruction text
        if (identifyFinished) instructionMessage.gameObject.SetActive(false);
        else instructionMessage.gameObject.SetActive(true);
        //slider
        identifySlider.value = timer / totalTime;
        if (identifySlider.value < 0.01f || identifySlider.value > 0.99f) identifySlider.gameObject.SetActive(false);
        else identifySlider.gameObject.SetActive(true);
    }
    public void IdentifyReset()
    {
        timer = 0;
        identifyFinished = false;
        sprite.gameObject.SetActive(false);
        contents.SetActive(false);
    }
    public void IdentifyFinished()
    {
        timer = totalTime;
        identifyFinished = true;
        sprite.gameObject.SetActive(true);

        if (currentBody == null)
        {
            Debug.LogWarning("No current body");
            return;
        }
        contents.SetActive(true);
        showInfo();
    }
    private void showInfo()
    {
        if (currentBody.bodyName != null) bodyName.text = currentBody.bodyName;
        if (currentBody.rank != null) rank.text = currentBody.rank;
        if (currentBody.DOB != null) DOB.text = currentBody.DOB;
        if (currentBody.backgroundStory != null) backgroundStory.text = currentBody.backgroundStory;
        if (currentBody.sprite != null) sprite.sprite = currentBody.sprite;
    }

}
