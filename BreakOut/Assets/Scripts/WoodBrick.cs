public class WoodBrick : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        resistance = 2;
        pointsValue = 150;
        resistance = GetBrickResistanceFromDifficulty(resistance, settings.difficultyLevel);
    }
}
