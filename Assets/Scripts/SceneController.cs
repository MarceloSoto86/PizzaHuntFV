using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Este script controla la transición entre escenas. Se encarga de cargar la escena "Nivel 2" cuando el jugador colisiona con un objeto.
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Nivel 2");
    }
}
