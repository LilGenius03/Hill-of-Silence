using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject camOld, camNew;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camOld.SetActive(false);
            camNew.SetActive(true);
        }
    }
}
