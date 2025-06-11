using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPosition;
    public GameObject enemyFactory;

    float createTime;
    float minTime = 0.5f;
    float maxTime = 1f;

    void Start()
    {
        CreateEnemy();
    }

    void CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyFactory);
        enemy.transform.position = spawnPosition[Random.Range(0, spawnPosition.Length)].position;
        createTime = Random.Range(minTime, maxTime);
        Invoke("CreateEnemy", createTime);
    }
}
