using UnityEngine;

namespace PowerUps
{
    public class SmallBallBrick : Brick
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

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
