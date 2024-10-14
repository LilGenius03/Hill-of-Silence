using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineFreeLook[] cameras;

    public CinemachineFreeLook thirdPersonCam;
    public CinemachineFreeLook lockCam;

    public CinemachineFreeLook startCam;
    private CinemachineFreeLook currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = startCam;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCamera)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }
    public void SwitchCamera(CinemachineFreeLook newCam)
    {
        Debug.Log("Switched camera");

        currentCamera = newCam;
        currentCamera.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        } 


    }
}
