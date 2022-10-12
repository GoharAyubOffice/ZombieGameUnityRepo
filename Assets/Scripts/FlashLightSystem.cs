using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField]  float angleDecay = 2f;
    [SerializeField] float minimumAngle = 40f;

    Light mylight;
    void Start()
    {
        mylight = GetComponent<Light>();
    }
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }
    public void DecreaseLightAngle()
    {
        if(mylight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            mylight.spotAngle -= angleDecay *Time.deltaTime;
        }
    }
    public void DecreaseLightIntensity()
    {
       mylight.intensity -= lightDecay * Time.deltaTime;
    }
    public void RestoreLightAngle(float restoreSpotAngle)
    {
        mylight.spotAngle = restoreSpotAngle;
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        mylight.intensity += intensityAmount;
    }
}
