using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _requiredItem;

    public GameObject GardaiInteractionText;

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
                GardaiInteractionText.SetActive(false);
                Destroy(gameObject);

            }
       }

    }



}
