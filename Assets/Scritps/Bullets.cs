using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bullet : MonoBehaviour
{
    public int BulletDamage = 10;
    public static int CantidadDead = 0;
    public TextMeshProUGUI enemigosDead;
    public GameObject explosionEffect; // Prefab de part�culas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigos"))
        {
            if (explosionEffect != null) // Asegura que haya efecto de part�culas
            {
                GameObject effect = Instantiate(explosionEffect, other.transform.position, Quaternion.identity);
                effect.transform.parent = null; // Evita que las part�culas se destruyan con el enemigo
            }

            Destroy(other.gameObject); // Destruye al enemigo
            Destroy(gameObject); // Destruye la bala

            CantidadDead++;
            if (enemigosDead != null)
            {
                enemigosDead.text = "EnemyDead: " + CantidadDead;
            }

            if (CantidadDead >= 10)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}