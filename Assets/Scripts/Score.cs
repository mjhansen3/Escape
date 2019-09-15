using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private float score;
    public float highScore;

    // Update is called once per frame
    void Update()
    {
        score = player.position.z;
        scoreText.text = score.ToString("0");

        if(score > highScore)
        {
            highScoreText.text = scoreText.text;
        }
    }
}
