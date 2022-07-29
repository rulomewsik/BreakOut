using System.Collections.Generic;
using UnityEngine;

public class LivesAdministrator : MonoBehaviour
{
    [HideInInspector] public List<GameObject> lives;
    public GameObject ballPrefab;
    private Ball _ballScript;
    public GameObject gameOverMenu;

    private void Start()
    {
        var children = GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            lives.Add(child.gameObject);
        }
    }

    public void LoseLife()
    {
        var objectToDelete = lives[^1];
        Destroy(objectToDelete);
        lives.RemoveAt(lives.Count -1);
        if (lives.Count <= 0)
        {
            gameOverMenu.SetActive(true);
            return;
        }

        var ball = Instantiate(ballPrefab);
        _ballScript = ball.GetComponent<Ball>();
        _ballScript.ballDestroyed.AddListener(LoseLife);
    }
}
