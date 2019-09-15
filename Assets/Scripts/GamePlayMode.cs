using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMode : MonoBehaviour
{
    public void ExitGamePlayMode()
    {
        SceneManager.LoadScene(0);
    }
}
