using System;
using UnityEngine;

public class BorderControl : MonoBehaviour
{
    [Header("Editor Configurations")] 
    public float radio = 1F;
    public bool keepOnScreen = false;

    [Header("Dynamic Configurations")] 
    public bool isOnScreen = true;
    public float cameraWidth;
    public float cameraHeight;
    public bool wentRight, wentLeft, wentUp, wentDown;

    private void Awake()
    {
        if (Camera.main == null) return;
        var main = Camera.main;
        cameraHeight = main.orthographicSize;
        cameraWidth = main.aspect * cameraHeight;
    }

    private void LateUpdate()
    {
        var position = transform.position;
        isOnScreen = true;
        wentRight = wentLeft = wentUp = wentDown = false;

        if (position.x > cameraWidth - radio)
        {
            position.x = cameraWidth - radio;
            wentRight = true;
        }
        if (position.x < -cameraWidth + radio)
        {
            position.x = -cameraWidth + radio;
            wentLeft = true;
        }
        if (position.y > cameraHeight - radio)
        {
            position.y = cameraWidth - radio;
            wentUp = true;
        }
        if (position.y < -cameraHeight + radio)
        {
            position.x = -cameraHeight + radio;
            wentDown = true;
        }
        
        isOnScreen = !(wentRight || wentLeft || wentUp || wentDown);
        
        if (!keepOnScreen || isOnScreen) return;
        transform.position = position;
        isOnScreen = true;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        var borderSize = new Vector3(cameraWidth * 2, cameraHeight * 2, 0.1F);
        Gizmos.DrawWireCube(Vector3.zero, borderSize);
    }
}
