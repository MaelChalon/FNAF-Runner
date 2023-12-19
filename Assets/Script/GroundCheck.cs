using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGroundTouched = true;

    private void OnTriggerEnter(Collider other)
    {
        isGroundTouched = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGroundTouched = false;
    }
}