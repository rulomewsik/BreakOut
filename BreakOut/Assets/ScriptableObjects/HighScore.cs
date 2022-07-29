using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "HighScore", menuName = "Tools/HighScore", order = 0)]
    public class HighScore : PersistentScore
    {
        public int score;
        public int highScore;
    }
}