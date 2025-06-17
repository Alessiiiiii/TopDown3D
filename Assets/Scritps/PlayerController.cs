using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform targetObject;

    public float gravityForce;
    [Range(1f, 10f)]
    public float movementSpeed;

    private float verticalVelocity;
    public Vector2 movementInput;
    public Vector2 mousePosition;
    public Vector3 lookTarget;
    private CharacterController characterController;
    [Header("Disparo")]
    public GameObject Bala; // Prefab de la bala
    public Transform Spawner; // Lugar desde donde se dispara
    public float velocidadBala = 60f;
    public int collectedItems;




    public TMPro.TextMeshProUGUI scoreText;

    public TMPro.TextMeshProUGUI GameOverText;

   

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        GameOverText.enabled = false;
    }

   public void Update()
    {
        if (!characterController.isGrounded)
        {

            verticalVelocity = gravityForce * Time.deltaTime;
        }

        float movementX = (movementInput.x * movementSpeed * Time.deltaTime);
        float movementZ = (movementInput.y * movementSpeed * Time.deltaTime);

        Vector3 finalMovement = new Vector3(movementX, verticalVelocity, movementZ);

        characterController.Move(finalMovement);

        lookTarget.y = transform.position.y;
        transform.LookAt(lookTarget);
        Debug.Log("Posición del jugador: " + transform.position);

    }
    public void OnMove(InputAction.CallbackContext context)
    {

        movementInput = context.ReadValue<Vector2>();
        Debug.Log("Movement Input: " + movementInput);
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {

        mousePosition = context.ReadValue<Vector2>();
        Debug.Log("Mouse Postion: " + mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float enter))
        {
            lookTarget = ray.GetPoint(enter);

        }
    }
    public void OnDisparar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bala = Instantiate(Bala, Spawner.position, Spawner.rotation);
            Rigidbody rbBala = bala.GetComponent<Rigidbody>();
            rbBala.linearVelocity = Spawner.forward * velocidadBala;
            Destroy(bala, 3f); // La bala se autodestruye tras 3 segundos


            Debug.Log("¡Disparo!");
        }
    }

}
