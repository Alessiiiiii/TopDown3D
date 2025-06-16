using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemigos;
    public float spawnInterval = 6f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 6f, spawnInterval);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemigos.Length);
        Instantiate(enemigos[index], transform.position, Quaternion.identity);
    }
}