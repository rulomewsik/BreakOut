using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public Settings settings;
    public bool isGameStarted;
    [SerializeField] public float ballSpeed;
    private Vector3 _lastPosition = Vector3.zero;
    private Vector3 _direction = Vector3.zero;
    private Rigidbody _rigidbody;
    private BorderControl _borderControl;
    public UnityEvent ballDestroyed;
    
    private void Awake()
    {
        _borderControl = GetComponent<BorderControl>();
        ballSpeed = settings.ballSpeed;
    }

    private void Start()
    {
        var initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialPosition.y += 2;
        transform.position = initialPosition;
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (_borderControl.wentDown)
        {
            ballDestroyed.Invoke();
            Destroy(gameObject);
        }
        if (_borderControl.wentUp)
        {
            _direction = transform.position - _lastPosition;
            _direction.y *= -1;
            _direction = _direction.normalized;
            _rigidbody.velocity = ballSpeed * _direction;
            _borderControl.wentUp = false;
            _borderControl.enabled = false;
            Invoke(nameof(EnableBorderControl), 0.2F);
        }
        if (_borderControl.wentLeft)
        {
            _direction = transform.position - _lastPosition;
            _direction.x *= -1;
            _direction = _direction.normalized;
            _rigidbody.velocity = ballSpeed * _direction;
            _borderControl.wentLeft = false;
            _borderControl.enabled = false;
            Invoke(nameof(EnableBorderControl), 0.2F);
        }
        if (_borderControl.wentRight)
        {
            _direction = transform.position - _lastPosition;
            _direction.x *= -1;
            _direction = _direction.normalized;
            _rigidbody.velocity = ballSpeed * _direction;
            _borderControl.wentRight = false;
            _borderControl.enabled = false;
            Invoke(nameof(EnableBorderControl), 0.2F);
        }
        
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

    private void FixedUpdate()
    {
        _lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (!_direction.Equals(Vector3.zero)) _direction = Vector3.zero;
        ballSpeed = settings.ballSpeed;
    }

    private void EnableBorderControl()
    {
        _borderControl.enabled = true;
    }
}