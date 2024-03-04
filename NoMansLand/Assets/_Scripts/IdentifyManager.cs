using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using System.Xml.Serialization;

public class IdentifyManager : MonoBehaviour
{
    public TMP_Text instructionMessage;
    public Slider identifySlider;

    public List<IdentifyBody> bodies = new List<IdentifyBody>();
    public IdentifyBody examiningBody;
    public IdentifyBody draggingBody;
    public float totalTime = 1f;

    [Header("private fields")]
    [SerializeField] private float timer = 0;

    [SerializeField] private InputActionReference identify, unidentify, drag, drop;
    
    #region singleton
    private static IdentifyManager _instance;
    public static IdentifyManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }
    #endregion
    private void OnEnable()
    {
        identify.action.performed += IdentifyButtonPressed;
        identify.action.canceled += IdentifyButtonReleased;
        unidentify.action.performed += UnidentifyButtonPressed;
        drag.action.performed += DragButtonPressed;
        drop.action.performed += DropButtonPressed;
    }

    private void OnDisable()
    {
        identify.action.performed -= IdentifyButtonPressed;
        identify.action.canceled -= IdentifyButtonReleased;
        unidentify.action.performed -= UnidentifyButtonPressed;
        drag.action.performed -= DragButtonPressed;
        drop.action.performed -= DropButtonPressed;
    }
    private void IdentifyButtonPressed(InputAction.CallbackContext context)
    {
        if (examiningBody != null) ShowInfoCheck(examiningBody);
        if (draggingBody != null) ShowInfoCheck(draggingBody);

        HandleInstructions();
    }
    private void IdentifyButtonReleased(InputAction.CallbackContext obj)
    {
        IdentifyCheck();

        HandleInstructions();
    }
    public void UnidentifyButtonPressed(InputAction.CallbackContext obj)
    {
        if (examiningBody != null) examiningBody.HideInfo();
        if (draggingBody != null) draggingBody.HideInfo();

        HandleInstructions();
    }
    private void DragButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Drag");
        if (examiningBody == null) return;
        if (draggingBody != null) draggingBody.DitchPlayer();

        draggingBody = examiningBody;
        draggingBody.GraspPlayer();
        examiningBody = null;


        HandleInstructions();
    }
    private void DropButtonPressed(InputAction.CallbackContext context)
    {
        if (draggingBody == null) return;
        draggingBody.DitchPlayer();
        if (examiningBody == null) draggingBody = examiningBody;
        draggingBody = null;

        HandleInstructions();
    }

    private void Start()
    {
        bodies.Clear();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Body");
        foreach (GameObject go in gos) bodies.Add(go.GetComponent<IdentifyBody>());
        IdentifyCheck();
        identifySlider.gameObject.SetActive(false);
    }

    private void ShowInfoCheck(IdentifyBody body)
    {
        if (body.identified)
        {
            body.ShowInfo();
            return;
        }

        timer = 0;
    }

    private void Update()
    {
        if (identify.action.inProgress)
        {
            timer += Time.deltaTime;
            if (timer > totalTime) IdentifyFinished();
        }

        identifySlider.value = timer / totalTime;
        if(identifySlider.value < 0.05 || identifySlider.value > 0.95) identifySlider.gameObject.SetActive(false) ;
        else identifySlider.gameObject.SetActive(true);
    }

    public void HandleInstructions()
    {
        instructionMessage.gameObject.SetActive(true);
        instructionMessage.text = "";

        if (examiningBody != null)
        {
            if (examiningBody.contents.activeSelf) instructionMessage.text += "Press 'Q' to closs \n";
            else instructionMessage.text += "Press 'E' to identify \n";
        }
        else if (draggingBody != null)
        {
            if (draggingBody.contents.activeSelf) instructionMessage.text += "Press 'Q' to closs \n";
            else instructionMessage.text += "Press 'E' to identify \n";
        }

        if (examiningBody == null && draggingBody == null) return;
        if (examiningBody != null && draggingBody == null )
        {
            instructionMessage.text += "Press 'F' to drag \n";
        }
        if (examiningBody == null && draggingBody != null )
        {
            instructionMessage.text += "Press 'SPACE' to drop \n";
        }
        if(examiningBody != null && draggingBody != null)
        {
            instructionMessage.text += "You can only drag one person \n";
            instructionMessage.text += "Press 'F' to replace \n";
            instructionMessage.text += "Press 'SPACE' to drop \n";
        }
    }
    
    public void IdentifyCheck()
    {
        timer = 0;
    }
    public void IdentifyFinished()
    {
        timer = totalTime;
        if (examiningBody != null)
        {
            examiningBody.identified = true;
            examiningBody.ShowInfo();
        }
        if (draggingBody != null)
        {
            draggingBody.identified = true;
            draggingBody.ShowInfo();
        }

    }

}
