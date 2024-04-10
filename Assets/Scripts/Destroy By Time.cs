using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime = 4f; // Durée de vie de l'objet avant d'être détruit

    void Start()
    {
        Destroy(gameObject, lifetime); // Détruit l'objet après 'lifetime' secondes
    }
}
