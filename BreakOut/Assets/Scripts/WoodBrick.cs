using UnityEngine;

public class WoodBrick : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        resistance = 3;
    }

    protected override void BounceBall(Collision collision)
    {
        base.BounceBall(collision);
    }
}
