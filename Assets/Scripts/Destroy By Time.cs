using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime = 4f; // Dur�e de vie de l'objet avant d'�tre d�truit

    void Start()
    {
        Destroy(gameObject, lifetime); // D�truit l'objet apr�s 'lifetime' secondes
    }
}
