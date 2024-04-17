using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float mapLength; // Longueur de votre map
    public GameObject[] maps; // Vos maps
    public float threshold; // Seuil pour repositionner la map

    // Assurez-vous que cette m�thode est appel�e r�guli�rement
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

