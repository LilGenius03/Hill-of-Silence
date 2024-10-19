using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private bool coroutineAllowed;
    public GameObject LockInteracvtText;
    public GameObject LockExitText;

    [Header("Script References")]
    [SerializeField ]public CameraManager CM;
    [SerializeField] public LockInteractScript lockInteractScript;

    [Header("Lock Cylinders")]
    public GameObject wheelOneOBJ;
    public GameObject wheelTwoOBJ;
    public GameObject wheelThreeOBJ;

    [Header("Cabinet References")]
    public GameObject cabinetDoor1;
    public GameObject cabinetDoor2;
    public GameObject cabinetWalls;
    public GameObject HillofSilenceKey;

    [Header("Player Model Reference")]
    public GameObject playerModel;

    [Header("Numbers Shown")]
    public int wheelOneNumberShown;
    public int wheelTwoNumberShown;
    public int wheelThreeNumberShown;

    private int wheelOneCorrectNumber = 8;
    private int wheelTwoCorrectNumber = 0;
    private int wheelThreeCorrectNumber = 4;

    // Start is called before the first frame update
    private void Start()
    {
        coroutineAllowed = true;
        HillofSilenceKey.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                coroutineAllowed = false;
                RotateWheelOne();
                coroutineAllowed |= true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                coroutineAllowed = false;
                RotateWheelTwo();
                coroutineAllowed |= true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                coroutineAllowed = false;
                RotateWheelThree();
                coroutineAllowed |= true;
            }
        if(wheelOneNumberShown == wheelOneCorrectNumber && wheelTwoNumberShown == wheelTwoCorrectNumber && wheelThreeNumberShown == wheelThreeCorrectNumber)
        {
            Debug.Log("Lock is unlocked");
            UnlockCabinet();
        }


    }
    void RotateWheelOne ()
    {

        for (int i = 0; i <= 11; i++) 
        {
            wheelOneOBJ.transform.Rotate(0f, 0f, 1.5f);
        }

        coroutineAllowed = true;

        wheelOneNumberShown += 1;

        if(wheelOneNumberShown > 9)
        {
            wheelOneNumberShown = 0;
        }


    }

    void RotateWheelTwo()
    {
        for(int i = 0; i <= 11; i++) 
        {
           wheelTwoOBJ.transform.Rotate(0f, 0f, 1.5f);
        }

        coroutineAllowed = true;

        wheelTwoNumberShown += 1;

        if (wheelTwoNumberShown > 9)
        {
            wheelTwoNumberShown = 0;
        }
    }

    void RotateWheelThree()
    {
        for(int i = 0; i <= 11; i++) 
        {
           wheelThreeOBJ.transform.Rotate(0f, 0f, 1.5f);
        }

        coroutineAllowed = true;

        wheelThreeNumberShown += 1;

        if (wheelThreeNumberShown > 9)
        {
            wheelThreeNumberShown = 0;
        }
    }

    void UnlockCabinet()
    {
        cabinetDoor1.SetActive(false);
        cabinetDoor2.SetActive(false);
        cabinetWalls.SetActive(false);
        HillofSilenceKey.SetActive(true);
        LockInteracvtText.SetActive(false);
        LockExitText.SetActive(false);
        CM.SwitchCamera(CM.thirdPersonCam);
        lockInteractScript.isPlayerCamActive = true;
        playerModel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
