using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float mapLength; 
    public GameObject[] maps; 
    public float threshold; // Seuil pour repositionner la map

    private void Update()
    {
        foreach (var map in maps)
        {
            // Si la map a défilé entièrement (sa position Z est inférieure à -mapLength), la réinitialiser
            if (map.transform.position.z <= -mapLength + threshold)
            {
                ResetMap(map);
            }
        }
    }

    private void ResetMap(GameObject map)
    {
        // Réinitialise la position de la map pour qu'elle apparaisse à la suite de la dernière map
        float offset = mapLength * (maps.Length - 1); // Calculer l'offset en fonction du nombre de maps
        map.transform.position = new Vector3(map.transform.position.x, map.transform.position.y, offset);
    }
}

