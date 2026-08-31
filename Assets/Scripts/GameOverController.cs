using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverController : MonoBehaviour
{
    // Estas variables se crearon para poder activar la animación de muerte del jugador y el menú de Game Over
    [SerializeField] private GameObject gameOverScreen; // Variable para el menú de Game Over
    [SerializeField] private HealthPoints healthPoints; // Variable para el script HealthPoints del jugador

    private void OnEnable()
    {
        if (healthPoints != null)
        {
            healthPoints.MuerteJugador += ActivarMenu; // Se suscribe al evento MuerteJugador del script HealthPoints del jugador
        }
    }


    // Este método se ejecuta cuando el jugador muere y activa el menú de Game Over
    private void ActivarMenu(object sender, EventArgs e)
    {
        Debug.Log("<color=green>EVENTO RECIBIDO: Activando pantalla GameOver</color>");
        gameOverScreen.SetActive(true); }

    //  Este método se ejecuta cuando el jugador presiona el botón de reiniciar nivel y recarga la escena actual

    private void OnDisable()
    {
        if (healthPoints != null)
        {
            healthPoints.MuerteJugador -= ActivarMenu; // Se desuscribe del evento MuerteJugador del script HealthPoints del jugador
        }
    }
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }

    // Este método se ejecuta cuando el jugador presiona el botón de volver al menú principal y carga la escena del menú principal
    public void ReturnGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Principal");
    }

    // Este método se ejecuta cuando el jugador presiona el botón de salir del juego y cierra la aplicación
    public void Salir()
    {
        Application.Quit();
    }
}
