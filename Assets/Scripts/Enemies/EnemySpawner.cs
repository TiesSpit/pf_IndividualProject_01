using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject gunEnemyPrefab;

    [SerializeField] private float minSpawnInterval = 1;
    [SerializeField] private float maxSpawnInterval = 5;

    float randomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {              
        InvokeRepeating(
            "SpawnEnemy",
            1,
            Random.Range(minSpawnInterval, maxSpawnInterval)
        );                    
    }

    //Spawns enemies
    void SpawnEnemy()
    {
        //Randomly choses which enemy to spawn
        randomNumber = Random.Range(0, 5);
        
        //Spawn normal enemy
        if (randomNumber <= 3)
        {
            Instantiate(
                enemyPrefab,
                transform.position,
                enemyPrefab.transform.rotation
            );
        }
        //Spawns gunEnemy
        else
        {
            Instantiate(
                gunEnemyPrefab,
                transform.position,
                gunEnemyPrefab.transform.rotation
            );
        }        
    }
}
