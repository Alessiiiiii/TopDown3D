using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemigos; // Array de prefabs de enemigos
    public Transform[] spawnPoints; // Lugares donde aparecen los enemigos
    public int maxEnemigos = 30; // Límite de enemigos simultáneos
    public float tiempoEntreOleadas = 5f; // Tiempo entre cada oleada

    private int enemigosActuales = 0;
    private bool puedeSpawnear = true;

    void Start()
    {
        StartCoroutine(SpawnOleadas());
    }

    IEnumerator SpawnOleadas()
    {
        while (puedeSpawnear)
        {
            yield return new WaitForSeconds(tiempoEntreOleadas);

            if (enemigosActuales < maxEnemigos)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        if (enemigos.Length == 0 || spawnPoints.Length == 0)
        {
            Debug.LogError("No hay enemigos o puntos de spawn asignados.");
            return;
        }

        int index = Random.Range(0, enemigos.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject enemyPrefab = enemigos[index];

        if (enemyPrefab == null)
        {
            Debug.LogError("Prefab de enemigo es NULL.");
            return;
        }

        GameObject enemigoNuevo = Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        enemigosActuales++;
    }

    public void EliminarEnemigo(GameObject enemigo)
    {
        Destroy(enemigo);
        enemigosActuales--;
        if (enemigosActuales < 0) enemigosActuales = 0; // Previene valores negativos
    }
}