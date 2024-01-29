using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class destroy : MonoBehaviour
{
    public GameObject DestroyedObject;
    public float time = 10f;

    public void Destroyed()
    {
        Instantiate(DestroyedObject, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(DestroyedObject, time);
    }
}
