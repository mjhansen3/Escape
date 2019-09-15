using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelNumberText;

    void Update()
    {
        levelNumberText.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
