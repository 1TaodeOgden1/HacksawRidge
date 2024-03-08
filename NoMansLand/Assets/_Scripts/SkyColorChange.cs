using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColorChange : MonoBehaviour
{
    public Timer timer;
    public float endLightAngle;
    public float startLightAngle;
    public float ambientEndIntensity;
    [SerializeField] private float rotateInterval;
    [SerializeField] private float intensityInterval;
    private float timerBuffer;

    private float initialAngle;
    public float initialIntensity = 1.0f;
    void Start()
    {
        transform.eulerAngles = new Vector3(initialAngle, 0,0);
        RenderSettings.ambientIntensity = initialIntensity;
        timer = FindObjectOfType<Timer>();

        rotateInterval = (endLightAngle - startLightAngle) / timer.timeRemaining;
        intensityInterval = (ambientEndIntensity - RenderSettings.ambientIntensity) / timer.timeRemaining;
    }

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.right, rotateInterval * Time.deltaTime);
        RenderSettings.ambientIntensity += intensityInterval * Time.deltaTime;
    }

}
