using UnityEngine;

namespace PowerUps
{
    public class ExtraLifeBrick : Brick
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        protected override void BounceBall(Collision collision)
        {
            base.BounceBall(collision);
            GiveExtraLife();
        }

        private void GiveExtraLife()
        {
            
        }
    }
}
