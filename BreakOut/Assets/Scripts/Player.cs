using System;
using ScriptableObjects;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int playerLimitX = 24;
    [SerializeField] public float playerSpeed = 50.0F;
    private Vector3 _mousePosition2D;
    private Vector3 _mousePosition3D;

    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = new Vector3(1F, GetPaddleSizeFromDifficulty(settings.difficultyLevel), 2F);
    }

    private float GetPaddleSizeFromDifficulty(Settings.Difficulty difficultyLevel)
    {
        return difficultyLevel switch
        {
            Settings.Difficulty.Easy => 6.0F,
            Settings.Difficulty.Medium => 4.0F,
            Settings.Difficulty.Hard => 2.0F,
            _ => 4.0F
        };
    }

    private void LateUpdate()
    {
        //transform.localScale = new Vector3(1F, GetPaddleSizeFromDifficulty(settings.difficultyLevel), 2F);
    }

    // Update is called once per frame
    void Update()
    {
        var playerTransform = transform;

        // _mousePosition2D = Input.mousePosition;
        // _mousePosition2D.z = -Camera.main.transform.position.z;
        // _mousePosition3D = Camera.main.ScreenToWorldPoint(_mousePosition2D);

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     playerTransform.Translate(Vector3.down * (playerSpeed * Time.deltaTime));
        // }
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     playerTransform.Translate(Vector3.up * (playerSpeed * Time.deltaTime));
        // }
        
        playerTransform.Translate(Vector3.down * (Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime));

        //playerPosition.x = _mousePosition3D.x;
        var playerPosition = playerTransform.position;
        
        if (playerPosition.x < -playerLimitX)
        {
            playerPosition.x = -playerLimitX;
        }
        else if (playerPosition.x > playerLimitX)
        {
            playerPosition.x = playerLimitX;
        }

        playerTransform.position = playerPosition;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BounceBall(collision);
        }
    }

    private void BounceBall(Collision collision)
    {
        var direction = collision.contacts[0].point - transform.position;
        direction = direction.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direction;
    }
}