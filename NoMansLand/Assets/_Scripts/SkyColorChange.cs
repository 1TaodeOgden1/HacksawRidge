using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColorChange : MonoBehaviour
{
    public Timer timer;
    public float endLightAngle;
    public float startLightAngle;
    public float ambientEndIntensity;
    private float rotateInterval;
    private float intensityInterval;
    private float timerBuffer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        rotateInterval = (endLightAngle - startLightAngle) / timer.timeRemaining * Time.deltaTime;
        intensityInterval = (ambientEndIntensity - RenderSettings.ambientIntensity) / timer.timeRemaining * Time.deltaTime; 
    }

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.right, rotateInterval);
        RenderSettings.ambientIntensity += intensityInterval;
    }

}