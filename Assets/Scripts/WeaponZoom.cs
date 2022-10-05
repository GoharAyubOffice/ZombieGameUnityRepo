using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraFPS;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    public float zoomOutFOV = 60;
    public float zoominFOV = 20;

    float zoominSenstivity =.5f;
    float zoomoutSenstivity =2f;

    [SerializeField] bool isToggleZoom = false;
    private void OnDisable() 
    {
        ZoomOut();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(isToggleZoom == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }
    private void ZoomIn()
    {
        isToggleZoom = true;
        cameraFPS.fieldOfView = zoominFOV;

        fpsController.mouseLook.XSensitivity = zoominSenstivity;
        fpsController.mouseLook.YSensitivity = zoominSenstivity;
    }
    private void ZoomOut()
    {
        isToggleZoom = false;
        cameraFPS.fieldOfView = zoomOutFOV;

        fpsController.mouseLook.XSensitivity = zoomoutSenstivity;
        fpsController.mouseLook.YSensitivity = zoomoutSenstivity;
    }

    
}
