using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isGameStarted;
    [SerializeField] public float ballSpeed = 20.0F;
    
    // Start is called before the first frame update
    void Start()
    {
        var initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialPosition.y += 2;
        transform.position = initialPosition;
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit"))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = ballSpeed * Vector3.up;
            }
        }
    }
}