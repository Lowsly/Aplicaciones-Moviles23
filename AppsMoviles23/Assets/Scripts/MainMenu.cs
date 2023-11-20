using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton, resumeButton, resume;

    public bool isPaused = false;

    public string scene;

    void Awake()
    {
        if(resume!= null)
        {
            if (PlayerPrefs.GetInt("round", 0)== 0)
                resume.interactable = false;
            else 
                resume.interactable = true;
        }
    }

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

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
