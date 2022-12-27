using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBackgroundMusic : MonoBehaviour
{

    private static TestBackgroundMusic backgroundMusic;

    // CÓDIGO FUNCIONANDO:

    private void Awake()
    {

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


    }
        // CÓDIGO VIEJO:




        /*if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);

        }

        else
        {
            Destroy(gameObject);
        }*/
        //}

        // 2DO CÓDIGO PRUEBA

        /*public static TestBackgroundMusic instance;

        void Awake()
        { 
        if (instance != null)
                Destroy(gameObject);
        else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
                    }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "Nivel 1")
                TestBackgroundMusic.instance.GetComponent<AudioSource>().Pause();
        }*/

    }
