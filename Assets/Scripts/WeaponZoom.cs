using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraFPS;
    public float zoomOutFOV = 60;
    public float zoominFOV = 20;

    float zoominSenstivity =.5f;
    float zoomoutSenstivity =2f;

    RigidbodyFirstPersonController fpsController;
    bool isToggleZoom = false;

    private void Start() 
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();    
    }
    void Update()
    
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(isToggleZoom == false)
            {
            isToggleZoom = true;
            cameraFPS.fieldOfView = zoominFOV;

            fpsController.mouseLook.XSensitivity = zoominSenstivity;
            fpsController.mouseLook.YSensitivity = zoominSenstivity;
            }
            else
            {
                isToggleZoom = false;
                cameraFPS.fieldOfView = zoomOutFOV;

                fpsController.mouseLook.XSensitivity = zoomoutSenstivity;
                fpsController.mouseLook.YSensitivity = zoomoutSenstivity;
            }
        }
    }
}
