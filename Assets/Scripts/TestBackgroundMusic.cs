using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBackgroundMusic : MonoBehaviour
{
    // Variable estática para almacenar la instancia de música de fondo
    private static TestBackgroundMusic backgroundMusic;

    // Este método se ejecuta cuando el objeto se activa y se asegura de que solo haya una instancia de música de fondo en la escena
    private void Awake()
    {

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic"); // Busca todos los objetos con el tag "GameMusic" en la escena

        // Si hay más de un objeto con el tag "GameMusic", destruye este objeto para evitar duplicados
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


    }
 }
