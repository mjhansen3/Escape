using UnityEngine;

public class FinishTrigger : MonoBehaviour
{

    public GameManager gameManager;

    void OnTriggerEnter ()
    {
        gameManager.LevelCompleted();
    }
}
