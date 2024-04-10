using System.Collections;
using UnityEngine;

public class GameElementSpawner : MonoBehaviour
{
    public GameObject branchPrefab;
    public GameObject rockPrefab;
    public GameObject coinPrefab;
    public float spawnLimitLeft = -6;
    public float spawnLimitRight = 6;
    public float obstacleSpawnInterval = 5; // Intervalle pour les obstacles
    public float coinSpawnInterval = 3; // Intervalle pour les pi�ces

    void Start()
    {
        // Commence � g�n�rer des obstacles et des pi�ces
        StartCoroutine(SpawnObstacles());
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Choisissez al�atoirement entre branchPrefab et rockPrefab pour l'obstacle � g�n�rer
            GameObject obstaclePrefab = Random.Range(0, 2) == 0 ? branchPrefab : rockPrefab;
            Vector3 spawnPosition = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), 0, transform.position.z);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), 0, transform.position.z);
            Instantiate(coinPrefab, spawnPosition, Quaternion.Euler(90,0,0));

            yield return new WaitForSeconds(coinSpawnInterval);
        }
    }
}
