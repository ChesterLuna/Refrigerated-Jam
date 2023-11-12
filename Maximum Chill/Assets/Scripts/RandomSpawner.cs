using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> Enemies;
    [SerializeField] public List<GameObject> Spawners;

    [Header("Level Settings")]
    [SerializeField] float minSpawnTime = 0f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] bool loopingSpawn = true;
    [SerializeField] int maxEnemies = 30;
    int enemiesSpawned = 0;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);

        do
        {
            yield return StartCoroutine(SpawnInsideSpawner());
        }
        while (loopingSpawn && enemiesSpawned < maxEnemies);
        FindObjectOfType<LevelManager>().StartNextLevel();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnInsideSpawner();
    }

    private IEnumerator SpawnInsideSpawner()
    {
        int choosenIndex = Random.Range(0, Spawners.Count);
        SpawnerRange choosenSpawner = Spawners[choosenIndex].GetComponent<SpawnerRange>();
        Vector3 randomSpawnPos = new Vector3(choosenSpawner.RandomX(), choosenSpawner.RandomY());


        int enemyIndex = Random.Range(0, Enemies.Count);
        Instantiate(Enemies[enemyIndex], randomSpawnPos, transform.rotation);
        enemiesSpawned ++;

        float timeBetweenEnemies = Random.Range(minSpawnTime,maxSpawnTime);
        yield return new WaitForSeconds(timeBetweenEnemies);

    }
}
