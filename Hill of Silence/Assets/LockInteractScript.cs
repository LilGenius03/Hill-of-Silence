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
        isPlayerCamActive = true;
        lockLight.SetActive(false);
        StartCoroutine(ExampleCoroutine());
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerInteractWithLockText.SetActive(true);

            Debug.Log("Player can interact with lock");
            if(Input.GetKeyDown(KeyCode.F) && isPlayerCamActive == true)
            {
                CM.SwitchCamera(CM.lockCam);
                dickRichardsonModel.SetActive(false);
                LockExitText.SetActive(true);
                //ExampleCoroutine();
                isPlayerCamActive = false;
                lockLight.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.F) && isPlayerCamActive == false)
            {
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
    }

}
