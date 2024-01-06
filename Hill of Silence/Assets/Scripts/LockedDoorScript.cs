using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour
{

    public GameObject Shears;
    [SerializeField] InventoryManager.AllItems _requiredItem;

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
            
        }

        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
       if(HasRequiredItem(InventoryManager.AllItems.Key1) || HasRequiredItem(InventoryManager.AllItems.Key2) || HasRequiredItem(InventoryManager.AllItems.Key3))
       {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);

            }
       }

    }

    private void Update()
    {
        if(HasRequiredItem(InventoryManager.AllItems.Key1))
        {
            Shears.SetActive(true);
        }
    }


}
