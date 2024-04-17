using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // La position du joueur à suivre
    public Vector3 offset; // L'écart entre le joueur et la caméra

    void LateUpdate()
    {
        // Mise à jour de la position de la caméra pour suivre le joueur sans modifier la rotation de la caméra
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
    }
}
