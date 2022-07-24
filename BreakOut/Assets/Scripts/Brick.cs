using UnityEngine;

public class Brick : MonoBehaviour
{
    public int resistance = 1; 
    
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

    public virtual void BounceBall()
    {
        
    }
}
