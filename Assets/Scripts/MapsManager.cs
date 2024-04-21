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
            // Si la map a d�fil� enti�rement (sa position Z est inf�rieure � -mapLength), la r�initialiser
            if (map.transform.position.z <= -mapLength + threshold)
            {
                ResetMap(map);
            }
        }
    }

    private void ResetMap(GameObject map)
    {
        // R�initialise la position de la map pour qu'elle apparaisse � la suite de la derni�re map
        float offset = mapLength * (maps.Length - 1); // Calculer l'offset en fonction du nombre de maps
        map.transform.position = new Vector3(map.transform.position.x, map.transform.position.y, offset);
    }
}

