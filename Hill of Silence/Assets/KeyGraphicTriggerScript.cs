using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGraphicTriggerScript : MonoBehaviour
{
    public GameObject Shedkey;
    private LockedDoorScript _doorScript;
    public float PlaySeconds = 3f;

    private void Start()
    {
        _doorScript = GetComponent<LockedDoorScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _doorScript.HasRequiredItem(InventoryManager.AllItems.Key1)) 
        {
            StartCoroutine("ShedKey");
        }
    }

    IEnumerator ShedKey()
    {
        Shedkey.SetActive(true);
        yield return new WaitForSeconds(PlaySeconds);
        Shedkey.SetActive(false);
        Destroy(gameObject);
    }
}
