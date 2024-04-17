using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur
    public Vector3 offset; // Décalage de la position de la caméra par rapport au joueur

    void LateUpdate()
    {
        // Positionne la caméra derrière le joueur, en utilisant le décalage
        transform.position = player.position + offset;

        // Garde la rotation de la caméra fixe
        transform.rotation = Quaternion.Euler(new Vector3(20, 0, 0)); // Rotation ajustable si nécessaire
    }
}

