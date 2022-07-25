using UnityEngine;

public class WoodBrick : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        resistance = 3;
    }

    public override void BounceBall()
    {
        base.BounceBall();
    }
}
