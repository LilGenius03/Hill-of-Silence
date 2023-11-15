using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public ParticleSystem leafs;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leafs.Play();
        }
    }
}
