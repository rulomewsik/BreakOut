using System;
using UnityEngine;

public class ShowSubscriber : MonoBehaviour
{
    public ShowEvents subscriber;
    
    // Start is called before the first frame update
    void Start()
    {
        subscriber = GetComponent<ShowEvents>();
        subscriber.SpacePressed += SubscriberOnSpacePressed; 
    }

    private void SubscriberOnSpacePressed(object sender, EventArgs e)
    {
        Debug.Log("Evento Presionado jiji");
        subscriber.SpacePressed -= SubscriberOnSpacePressed;
    }
}