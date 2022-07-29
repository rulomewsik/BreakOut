public class StoneBrick : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        resistance = 3;
        pointsValue = 200;
        resistance = GetBrickResistanceFromDifficulty(resistance, settings.difficultyLevel);
    }
}