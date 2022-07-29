using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    public Settings settings;
    private Slider _speed;

    private void Start()
    {
        _speed = GetComponent<Slider>();
        _speed.value = settings.ballSpeed;
        _speed.onValueChanged.AddListener(delegate { ControlChanges(); });
    }

    private void ControlChanges()
    {
       settings.ChangeSpeed(_speed.value); 
    }
}
