using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyDropDown : MonoBehaviour
{
    public Settings settings;
    private Dropdown _difficulty;

    private void Start()
    {
        _difficulty = GetComponent<Dropdown>();
        _difficulty.value = (int) settings.difficultyLevel;
        _difficulty.onValueChanged.AddListener(delegate { settings.ChangeDifficulty(_difficulty.value); });
    }
}
