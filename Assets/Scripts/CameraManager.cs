using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // R�f�rence au transform du joueur
    public Vector3 offset; // D�calage de la position de la cam�ra par rapport au joueur

    void LateUpdate()
    {
        // Positionne la cam�ra derri�re le joueur, en utilisant le d�calage
        transform.position = player.position + offset;

        // Garde la rotation de la cam�ra fixe
        transform.rotation = Quaternion.Euler(new Vector3(20, 0, 0)); // Rotation ajustable si n�cessaire
    }
}

