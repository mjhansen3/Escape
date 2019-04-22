using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public float restartDelay = 3f;

    public GameObject completeLevelUI;

    public void LevelCompleted ()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame ()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("Game Over");

            // Restart game
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
