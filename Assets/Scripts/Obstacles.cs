using System.Collections;
using UnityEngine;

public class GameElementSpawner : MonoBehaviour
{
    public PlayerFeedback playerFeedback; // Référence au script PlayerFeedback
    public GameObject branchPrefab;
    public GameObject rockPrefab;
    public GameObject coinPrefab;
    public float spawnLimitLeft = -6;
    public float spawnLimitRight = 6;
    public float obstacleSpawnInterval = 5; // Intervalle pour les obstacles
    public float coinSpawnInterval = 3; // Intervalle pour les pièces

    void Start()
{
    playerFeedback = FindObjectOfType<PlayerFeedback>(); // Ceci trouve le script PlayerFeedback dans la scène
    if (playerFeedback == null)
    {
        Debug.LogError("Le script PlayerFeedback n'a pas été trouvé. Assurez-vous qu'il est attaché à un objet actif dans la scène.");
        return;
    }

    // Commence à générer des obstacles et des pièces
    StartCoroutine(SpawnObstacles());
    StartCoroutine(SpawnCoins());
}


    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Choisie aleatoirement branch ou rock 
            GameObject obstaclePrefab = Random.Range(0, 2) == 0 ? branchPrefab : rockPrefab;
            Vector3 spawnPosition = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), 0, transform.position.z);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Ajuster l'intervalle de génération en fonction du score
            float intervalAdjustment = playerFeedback.score / 2; 
            float adjustedInterval = Mathf.Clamp(obstacleSpawnInterval - intervalAdjustment, 1, obstacleSpawnInterval);

            yield return new WaitForSeconds(adjustedInterval);
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
