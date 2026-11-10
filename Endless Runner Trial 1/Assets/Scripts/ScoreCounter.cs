using UnityEngine;
using TMPro; // Ensure you are using TextMeshPro for UI

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    public int numberOfCoins = 0;
    public float pointsPerSecond = 100f;

    private float currentScore = 0f;
    private bool playerAlive = true;

    private void Start()
    {
        UpdateHighScoreText();
    }

    void Update()
    {
        if (playerAlive)
        {
            // Time.deltaTime ensures consistent updates regardless of framerate
            currentScore += pointsPerSecond * Time.deltaTime;

            // Displays score as a whole number
            scoreText.text = "Score: " + Mathf.FloorToInt(currentScore).ToString();
            CheckHighScore();

        }
    }

    public void StopScoring()
    {
        playerAlive = false;
    }

    void CheckHighScore()
    {
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)currentScore);
            UpdateHighScoreText();
        }

    }

    void UpdateHighScoreText()
    {
        HighScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}