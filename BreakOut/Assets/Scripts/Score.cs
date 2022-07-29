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
        highScoreText.text = $"High Score: {highScoreSo.highScore}";
        highScoreSo.score = 0;
    }

    private void FixedUpdate()
    {
        highScoreSo.score += 50;
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
}
