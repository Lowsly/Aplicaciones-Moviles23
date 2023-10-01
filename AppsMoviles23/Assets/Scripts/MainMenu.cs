using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;

    public bool isPaused = false;

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        isPaused = true;
        pauseMenu.SetActive(true); 
        pauseButton.interactable = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
        pauseMenu.SetActive(false); 
        pauseButton.interactable = true; 
    }
}
