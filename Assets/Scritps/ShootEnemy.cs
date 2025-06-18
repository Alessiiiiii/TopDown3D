using UnityEngine;
using UnityEngine.InputSystem;

public class EnemigoDisparo : MonoBehaviour
{
    public GameObject BalaEnemigo; // Prefab del proyectil
    public Transform puntoDisparo; // Lugar desde donde dispara
    public Transform jugador; // Referencia al jugador
    public float velocidadBala = 20f;




    public void OnDisparar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bala = Instantiate(BalaEnemigo, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody rbBala = bala.GetComponent<Rigidbody>();
            rbBala.linearVelocity = puntoDisparo.forward * velocidadBala;
            Destroy(bala, 3f); // La bala se autodestruye tras 3 segundos


            Debug.Log("¡Disparo!");
        }
    }
}
