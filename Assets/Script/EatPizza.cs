using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EatPizza : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Colectible")
        {
            GameManager.Instance.addPizza();

            Destroy(collider.gameObject);
        }
    }
}
