using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Este script controla el menú de pausa del juego. Permite pausar y reanudar el juego, así como cargar el menú principal o salir del juego.
    public static bool isGamePaused = false;
    [SerializeField] GameObject optionsButton;
    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        // Este método se llama en cada frame y verifica si se ha presionado la tecla Escape. Si el juego está pausado, se reanuda; de lo contrario, se pausa.
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

    // Este método reanuda el juego, desactiva el menú de pausa y establece la escala de tiempo a 1
    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Este método pausa el juego, activa el menú de pausa y establece la escala de tiempo a 0
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        optionsButton.SetActive(true);
    }

    // Este método carga la escena actual, lo que efectivamente reinicia el juego
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Este método carga la escena del menú principal, que se asume que tiene un índice de 0
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }

}
