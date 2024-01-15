using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    public UnityEvent ItemCollected, ItemGone;
    public float displayTime = 3f;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Collide");
            InventoryManager.Instance.AddItem(_itemType);
            ItemCollected.Invoke();
            StartCoroutine(DisplayTime());
        }
    }

    IEnumerator DisplayTime()
    {
        Debug.Log("Coroutine has started");
        yield return new WaitForSecondsRealtime(displayTime);
        ItemGone.Invoke();
        Destroy(gameObject);
        Debug.Log("Coroutine has ended");
    }
}
