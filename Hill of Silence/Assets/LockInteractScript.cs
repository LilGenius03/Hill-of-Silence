using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockInteractScript : MonoBehaviour
{
    public CameraManager CM;
    public bool isPlayerCamActive;
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

            Debug.Log("Player can interact with lock");
            if(Input.GetKeyDown(KeyCode.E) && isPlayerCamActive == true)
            {
                CM.SwitchCamera(CM.lockCam);
                dickRichardsonModel.SetActive(false);
                //ExampleCoroutine();
                isPlayerCamActive = false;
                lockLight.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.E) && isPlayerCamActive == false)
            {
                dickRichardsonModel.SetActive(true);
                CM.SwitchCamera(CM.thirdPersonCam);
                lockLight.SetActive(false);
                //ExampleCoroutine();
                isPlayerCamActive = true;
            } 
        }
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
