using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{
   
    [SerializeField] private GameObject PressF;

    private void Start()
    {
       PressF.SetActive(false);
    }
    void TeleportPlayerToBathroom()
    {
        
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    /*void TeleportPlayerToSewer()
    {
        if(isInSewer == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            isInSewer=true;
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            isInSewer = false;
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        PressF.SetActive(true);
        if(other.CompareTag("Player"))
        {
            TeleportPlayerToBathroom();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PressF.SetActive(false);
    }

}
