using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionEscenaFinal : MonoBehaviour
{
    // Este script se encarga de cambiar a la escena "FinalDemo" cuando el objeto colisiona con otro objeto.
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("FinalDemo");
    }
}
