namespace PowerUps
{
    public class ExtraLifeBrick : Brick
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public override void BounceBall()
        {
            base.BounceBall();
            GiveExtraLife();
        }

        private void GiveExtraLife()
        {
            
        }
    }
}
