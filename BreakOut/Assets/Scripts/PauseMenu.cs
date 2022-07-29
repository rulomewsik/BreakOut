using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        if(settingsMenu.activeInHierarchy) settingsMenu.SetActive(false);
    }
    
    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
    
    public void ShowSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    
    public void ShowMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
