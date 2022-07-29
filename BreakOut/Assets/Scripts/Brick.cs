using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public int resistance = 1;
    public int pointsValue = 100;
    public Settings settings;
    public HighScore highScoreSo;
    public UnityEvent brickDestroyed;

    private void Awake()
    {
        resistance = GetBrickResistanceFromDifficulty(resistance, settings.difficultyLevel);
    }

    void Update()
    {
        if (resistance > 0) return;
        highScoreSo.score += pointsValue;
        brickDestroyed.Invoke();
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BounceBall(collision);
        }
    }

    protected virtual void BounceBall(Collision collision)
    {
        var direction = collision.contacts[0].point - transform.position;
        direction = direction.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direction;
        resistance--;

        var currentColor = GetComponent<MeshRenderer>().material.color;
        var darkerColor = new Color(currentColor.r - 0.2F, currentColor.g - 0.2F, currentColor.b - 0.2F);
        GetComponent<MeshRenderer>().material.color = darkerColor;
    }
    
    protected int GetBrickResistanceFromDifficulty(int level, Settings.Difficulty difficultyLevel)
    {
        return difficultyLevel switch
        {
            Settings.Difficulty.Easy => level,
            Settings.Difficulty.Medium => level + 1,
            Settings.Difficulty.Hard => level + 2,
            _ => 1
        };
    }
}