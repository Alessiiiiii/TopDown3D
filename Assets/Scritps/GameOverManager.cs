using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        Invoke("ReiniciarJuego", 5f); // Reinicia despu�s de 5 segundos
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(0);
    }
}