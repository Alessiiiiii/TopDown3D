using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform playerTrasnform; // Referencia al jugador
    private NavMeshAgent navMeshAgent; // Componente NavMeshAgent para el movimiento del enemigo
    [SerializeField] private float refreshRate = 0.5f;// Frecuencia de actualización del movimiento del enemigo
    public float speed = 3f;
    public float range = 10f;
    public int health = 10;
    private void Awake()
    {
        playerTrasnform = GameObject.FindWithTag("Player")?.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        InvokeRepeating("FindPlayer", 0f, refreshRate); // Llama al método FindPlayer cada refreshRate segundos
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindPlayer()
    {

        navMeshAgent.SetDestination(playerTrasnform.position); // Mueve al enemigo hacia la posición del jugador

    }
    public void ChangeHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (spawner != null)
            {
                spawner.EnemyDefeated();
            }
            Destroy(gameObject);
        }
    }
}





