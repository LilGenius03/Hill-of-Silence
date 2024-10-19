using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockInteractScript : MonoBehaviour
{
    public CameraManager CM;
    public bool isPlayerCamActive;
    public GameObject PlayerInteractWithLockText;
    public GameObject LockExitText;
    [SerializeField] GameObject lockLight;

    public GameObject dickRichardsonModel;
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerInteractWithLockText.SetActive(false);
        isPlayerCamActive = true;
        lockLight.SetActive(false);
        StartCoroutine(ExampleCoroutine());
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerInteractWithLockText.SetActive(true);
            if(Input.GetKey(KeyCode.F) && isPlayerCamActive == true)
            {

                PlayerInteractWithLockText.SetActive(false);
                CM.SwitchCamera(CM.lockCam);
                dickRichardsonModel.SetActive(false);
                LockExitText.SetActive(true);
                //ExampleCoroutine();
                lockLight.SetActive(true);
                isPlayerCamActive = false;
            }
            else if(Input.GetKey(KeyCode.F) && isPlayerCamActive == false)
            {

                PlayerInteractWithLockText.SetActive(false);
                dickRichardsonModel.SetActive(true);
                CM.SwitchCamera(CM.thirdPersonCam);
                LockExitText?.SetActive(false);
                lockLight.SetActive(false);
                //ExampleCoroutine();
                isPlayerCamActive = true;
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInteractWithLockText.SetActive(false);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
    }

}
