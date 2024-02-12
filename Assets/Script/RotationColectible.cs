using UnityEngine;

public class RotationColectible : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 0); // Vitesse de rotation en degr�s par seconde

    void Update()
    {
        // Faire tourner le GameObject selon la vitesse de rotation sp�cifi�e
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
