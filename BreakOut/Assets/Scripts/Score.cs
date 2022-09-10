using ScriptableObjects;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform highScoreTransform;
    public Transform actualScoreTransform;
    public TMP_Text highScoreText;
    public TMP_Text actualScoreText;
    public HighScore highScoreSo;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoreTransform = GameObject.Find("HighScore").transform;
        highScoreText = highScoreTransform.GetComponent<TMP_Text>();
        actualScoreTransform = GameObject.Find("ActualScore").transform;
        actualScoreText = actualScoreTransform.GetComponent<TMP_Text>();

        highScoreSo.Load();
        highScoreSo.score = 0;
        highScoreText.text = $"High Score: {highScoreSo.highScore}";
        actualScoreText.text = $"Actual Score: {highScoreSo.score}";
    }

    // Update is called once per frame
    void Update()
    {
        actualScoreText.text = $"Actual Score: {highScoreSo.score}";
        if (highScoreSo.score > highScoreSo.highScore)
        {
            highScoreSo.highScore = highScoreSo.score;
            highScoreText.text = $"High Score: {highScoreSo.highScore}";
            highScoreSo.Save();
        }
    }

    public void IncrementScore(int points)
    {
        highScoreSo.score += points;
    }
}
