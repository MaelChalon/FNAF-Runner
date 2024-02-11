using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{
    private GameObject lastCollider = null;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle" && lastCollider == null)
        {
            GameManager.Instance.hitObstacle();
            lastCollider = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle" && lastCollider == collider.gameObject)
        {
            lastCollider = null;
        }
    }
}
