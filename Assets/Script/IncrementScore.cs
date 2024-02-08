using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScore : MonoBehaviour
{
    private int lastCoordinateZ = 1;
    // Update is called once per frame
    void Update()
    {
        if (lastCoordinateZ < (int)gameObject.transform.position.z)
        {
            lastCoordinateZ = (int)gameObject.transform.position.z;
            GameManager.instance.addScore();
        }
    }
}
