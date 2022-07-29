using UnityEngine;

public class BrickAdministrator : MonoBehaviour
{
    public GameObject boardEndedMenu;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            boardEndedMenu.SetActive(true);
        }
    }
}
