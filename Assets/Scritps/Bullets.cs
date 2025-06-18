using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bullet : MonoBehaviour
{
    public int BulletDamage = 10;
    public static int CantidadDead =0;
    public TextMeshProUGUI enemigosDead;
    public GameObject explosionEffect; // Prefab de partículas
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (explosionEffect != null) // Asegura que haya efecto de partículas
            {
                GameObject effect = Instantiate(explosionEffect, other.transform.position, Quaternion.identity);
                effect.transform.parent = null; // Evita que las partículas se destruyan con el enemigo
            }
            if (other.gameObject != null)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Debug.LogError("Intentando destruir un objeto ya eliminado.");
            }

            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject, 0.1f);

            CantidadDead++;
            if (enemigosDead != null)
            {
                enemigosDead.text = "EnemyDead: " + CantidadDead;
            }
            else
            {
                Debug.LogError("Texto de enemigos muertos no está asignado.");
            }

            if (CantidadDead >= 15)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}