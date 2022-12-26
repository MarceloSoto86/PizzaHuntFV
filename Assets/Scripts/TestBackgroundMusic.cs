using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBackgroundMusic : MonoBehaviour
{

    private static TestBackgroundMusic backgroundMusic;


    private void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);

        }

        else
        {
            Destroy(gameObject);
        }
    }
}
