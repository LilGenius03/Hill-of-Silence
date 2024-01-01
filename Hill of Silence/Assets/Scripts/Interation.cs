using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;

public class Interation : MonoBehaviour
{
    public UnityEvent enteredInteration, exitedInteration, interacted;
    private bool interactionEnabled;
    public bool interactedEnabled = true;

    private void Start()
    {
        interactedEnabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enteredInteration.Invoke();
            interactionEnabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            exitedInteration.Invoke();
            interactionEnabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interactionEnabled && Input.GetKeyDown(KeyCode.F))
        {
            exitedInteration.Invoke();
            interacted.Invoke();
            interactedEnabled = true;
            
        }

        

      
    }
}
