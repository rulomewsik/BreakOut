using System;
using UnityEngine;
using UnityEngine.Events;

public class ShowEvents : MonoBehaviour
{
    public UnityEvent myUnityEvent;
    public event EventHandler SpacePressed;

    // Start is called before the first frame update
    void Start()
    {
        SpacePressed += OnSpacePressed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpacePressed?.Invoke(this, EventArgs.Empty);
            myUnityEvent.Invoke();
        }
    }

    private void OnSpacePressed(object sender, EventArgs e)
    {
        Debug.Log("Evento Presionado jiji");
    }

    public void onUnityEventFired()
    {
        Debug.Log("Evento Unity Disparado yey");
    }
}