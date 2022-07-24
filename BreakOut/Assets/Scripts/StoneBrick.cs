using UnityEngine;

public class StoneBrick : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        resistance = 5;
    }
    
    public override void BounceBall()
    {
        base.BounceBall();
    }
}