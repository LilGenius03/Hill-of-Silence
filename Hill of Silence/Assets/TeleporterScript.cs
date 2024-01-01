using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public Transform Receiver;
    private Vector3 RsavedPos;
    Interation interaction;
    public Transform PlayerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<Interation>();
        RsavedPos = Receiver.transform.position;

    }

   public void TeleportPlayer()
   {
        if (interaction.interactedEnabled == true) 
        {
            PlayerPos.transform.position = RsavedPos;
        }

        

   }
}
