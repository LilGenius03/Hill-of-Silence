using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float RotationSpeed = 2f;

    private void Update()
    {
        transform.Rotate(RotationSpeed, 0, 0);
    }
}
