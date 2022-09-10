using UnityEngine;

namespace PowerUps
{
    public class SmallBallBrick : Brick
    {
        protected override void BounceBall(Collision collision)
        {
            base.BounceBall(collision);
            MakeBallSmaller();
        }

        private void MakeBallSmaller()
        {
            
        }
    }
}
