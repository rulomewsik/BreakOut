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
}