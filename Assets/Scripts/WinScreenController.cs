using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    // Este script controla la pantalla de victoria del juego. Se encarga de activar la pantalla de victoria cuando el jugador colisiona con un objeto que tiene el tag "Finish" y pausar el juego.
    [SerializeField] GameObject winScreen;

    public void OnCollisionEnter(Collision collision)
    {
        // Si el jugador colisiona con un objeto que tiene el tag "Finish", se activa la pantalla de victoria y se pausa el juego
        winScreen.SetActive(true);
       Time.timeScale = 0;
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu Principal");   
    }
}