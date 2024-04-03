using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public GameObject branchPrefab; // Assignez votre prefab de branche dans l'inspecteur
    public GameObject rockPrefab; // Assignez votre prefab de roche dans l'inspecteur
    public float spawnLimitLeft = -6;
    public float spawnLimitRight = 6;
    public float spawnInterval = 5; // Intervalle de temps entre les spawns d'obstacles

    // Start est appel� avant le premier frame update
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // G�n�rer le premier obstacle
            Vector3 spawnPosition1 = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), 0, transform.position.z);
            GameObject obstaclePrefab1 = Random.Range(0, 2) == 0 ? branchPrefab : rockPrefab;
            Instantiate(obstaclePrefab1, spawnPosition1, Quaternion.identity);

            // Attendre un moment avant de g�n�rer le deuxi�me obstacle, pour diversifier
            yield return new WaitForSeconds(spawnInterval / 2);

            // G�n�rer le deuxi�me obstacle
            Vector3 spawnPosition2 = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), 0, transform.position.z);
            GameObject obstaclePrefab2 = Random.Range(0, 2) == 0 ? branchPrefab : rockPrefab;
            Instantiate(obstaclePrefab2, spawnPosition2, Quaternion.identity);

            // Attendre l'intervalle de spawn avant de g�n�rer � nouveau
            yield return new WaitForSeconds(spawnInterval / 2);
        }
    }
}
