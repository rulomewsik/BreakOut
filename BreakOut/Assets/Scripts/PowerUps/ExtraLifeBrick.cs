using UnityEngine;

namespace PowerUps
{
    public class ExtraLifeBrick : Brick
    {
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
