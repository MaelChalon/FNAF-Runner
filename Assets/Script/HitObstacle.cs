using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.hitObstacle();
        }
    }
}
