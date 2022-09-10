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

    public void AddLife()
    {
        Transform parentTransform;
        var originalGo = (parentTransform = transform).GetChild(parentTransform.childCount - 1);
        var position = originalGo.position;
        var rectTransform = (RectTransform)originalGo.transform;
        
        var newLifeGo = Instantiate(originalGo, new Vector3(position.x + rectTransform.rect.width + 4, position.y), Quaternion.identity, parentTransform);
        lives.Add(newLifeGo.gameObject);
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
