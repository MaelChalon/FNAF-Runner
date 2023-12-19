using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EndCoridor : MonoBehaviour
{
    public List<GameObject> Coridors = new List<GameObject>();
    private static int Position = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //on fait apparaitre le prochain coridor
            spawnNewCoridor();

            //On détruit le coridore précédant
            //DestroyCoridor();
        }
    }

    private void spawnNewCoridor()
    {
        if (Coridors.Count > 0)
        {
            Position += 10;
            Vector3 spawnPoint = new Vector3(0,0,Position);

            GameObject.Instantiate(Coridors[0], spawnPoint, Quaternion.identity);
        }
    }
}
