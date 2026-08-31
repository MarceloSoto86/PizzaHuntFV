using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinExitScreen : MonoBehaviour
{
    // Este método se ejecuta cuando el jugador colisiona con el objeto que tiene este script y carga la escena "Counter"
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Counter");
    }
}
