using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Tools/Settings", order = 1)]
    public class Settings : ScriptableObject
    {
        public float ballSpeed = 30F;
        public Difficulty difficultyLevel = Difficulty.Easy;
        
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }

        public void ChangeSpeed(float newSpeed)
        {
            ballSpeed = newSpeed;
        }

        public void ChangeDifficulty(int newDifficulty)
        {
            difficultyLevel = (Difficulty) newDifficulty;
        }
    }
}
