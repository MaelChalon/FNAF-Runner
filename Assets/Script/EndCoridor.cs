using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EndCoridor : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //on fait apparaitre le prochain coridor
            GameManager.Instance.spawnNewCoridor();

            //On d�truit le coridore pr�c�dant
            DestroyCoridor();
        }
    }

    private void DestroyCoridor()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
    
    
}
