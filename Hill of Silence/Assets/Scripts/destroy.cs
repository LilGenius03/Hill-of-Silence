using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class destroy : MonoBehaviour
{
    public GameObject DestroyedObject;
    public Transform objectTransform;
    public float time = 100f;

    public void Destroyed()
    {
        Instantiate(DestroyedObject, objectTransform.position, objectTransform.rotation);
        Destroy(gameObject);
        Destroy(DestroyedObject, time);
    }
}
