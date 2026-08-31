using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostPro : MonoBehaviour
{
    // Este script controla el efecto de postprocesamiento en la escena. Se encarga de aumentar el peso del volumen de postprocesamiento global cuando se activa.
    [SerializeField] private PostProcessVolume _postProcessVolume;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Si el volumen de postprocesamiento es global, se aumenta su peso gradualmente hasta llegar a 1.
        if (_postProcessVolume.isGlobal == true)
        {
            _postProcessVolume.weight = Mathf.Lerp(_postProcessVolume.weight, 1f, Time.deltaTime);
        }
        
        
    }
}
