using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject optionsButton;

    [SerializeField] GameObject pauseMenu;
   
    //[SerializeField] GameObject loadButton;
    //[SerializeField] GameObject saveButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }

        
    }


    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

    }


    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        optionsButton.SetActive(true);
        //loadButton.SetActive(true);
        //saveButton.SetActive(true);
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }

}
