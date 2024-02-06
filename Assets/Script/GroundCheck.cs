using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGroundTouched = false;
    private bool enterNextCorridor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (isGroundTouched)
            {
                enterNextCorridor = true;
            }
            else
            {
                isGroundTouched = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (!enterNextCorridor)
            {
                isGroundTouched = !isGroundTouched;
            }
            else
            {
                enterNextCorridor = false;
            }

        }
    }
}