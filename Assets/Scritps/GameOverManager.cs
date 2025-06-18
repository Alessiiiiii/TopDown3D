using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        
        Bullet.CantidadDead = 0;
        SceneManager.LoadScene(1);
    }
}
