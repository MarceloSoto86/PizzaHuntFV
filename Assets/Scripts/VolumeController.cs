using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; 
    //public GameObject ObjectMusic;


    public float sliderValue;
    public Image imagenMute;


    //Código VIEJO debajo:

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumenAudio", sliderValue);
        AudioListener.volume = volumeSlider.value;
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {
        volumeSlider.value = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = volumeSlider.value;
        RevisarSiEstoyMute();


    }

    public void RevisarSiEstoyMute()
    {
        if (volumeSlider.value == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }





    //3er código PRUEBA

    //private float MusicVolume = 0f; // Agregado en nuevo código
    //private AudioSource AudioSource; // Agregado en nuevo código

    // CÓDIGO NUEVO:

    /*private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        // Set Volume
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;



    }

    private void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;
    }*/



}
