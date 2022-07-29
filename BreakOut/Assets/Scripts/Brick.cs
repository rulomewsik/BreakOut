using System;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public int resistance = 1;
    public UnityEvent IncrementScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resistance <= 0)
        {
            Destroy(gameObject);
        }
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
    }
}
