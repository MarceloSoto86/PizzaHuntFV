using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    // Variables públicas para el slider de volumen, el valor del slider y la imagen de mute
    public Slider volumeSlider; 
    public float sliderValue;
    public Image imagenMute;

    // Este método se ejecuta al iniciar la escena y establece el valor del slider de volumen según lo guardado en PlayerPrefs, actualiza el volumen del audio y revisa si el volumen es 0 para activar o desactivar la imagen de mute
    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumenAudio", sliderValue);
        AudioListener.volume = volumeSlider.value;
        RevisarSiEstoyMute();
    }

    // Este método se ejecuta cuando el jugador cambia el valor del slider de volumen y actualiza el volumen del audio y guarda el valor en PlayerPrefs
    public void ChangeSlider(float valor)
    {
        volumeSlider.value = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = volumeSlider.value;
        RevisarSiEstoyMute();
    }

    // Este método revisa si el volumen es 0 y activa o desactiva la imagen de mute en consecuencia
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
}
