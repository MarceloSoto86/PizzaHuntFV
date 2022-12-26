using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBackgroundMusic : MonoBehaviour
{

    private static TestBackgroundMusic backgroundMusic;


    private void Awake()
    {

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);



        /*if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);

        }

        else
        {
            Destroy(gameObject);
        }*/
    }
}
