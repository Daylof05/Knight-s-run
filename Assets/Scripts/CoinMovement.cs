using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement vers le joueur
    public float floatAmplitude = 0.5f; // Amplitude du "flottement"
    public float floatFrequency = 3f; // Fréquence du "flottement"
    public float rotationSpeed = 100f;

    private float originalY; // Position y originale pour le "flottement"

    void Start()
    {
        originalY +=2;
    }

    void Update()
    {
        // Mouvement vers le joueur
        transform.position += Vector3.forward * -speed * Time.deltaTime;

        // Effet de "flottement"
        float newY = originalY + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotation de la pièce sur elle-même
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
