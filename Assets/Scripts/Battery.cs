using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float intensityAmount = 5f;
    [SerializeField] float restoreSpotAngle = 90f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreSpotAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }    
    }
}
