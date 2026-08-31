using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering.PostProcessing;

public class PostProController : MonoBehaviour
{
    // Este script controla el perfil de postprocesamiento en la escena. Se encarga de cambiar el perfil de postprocesamiento del volumen de postprocesamiento global cuando se llama al método ChangeProfile.
    [SerializeField] PostProcessProfile defaultProfile;

    private void Start()
    {
        GetComponent<PostProcessVolume>().sharedProfile = defaultProfile; // Establece el perfil de postprocesamiento predeterminado al inicio
    }

    // Este método cambia el perfil de postprocesamiento del volumen de postprocesamiento global al perfil proporcionado como argumento.
    public void ChangeProfile(PostProcessProfile profile)
    {
        GetComponent<PostProcessVolume>().sharedProfile = profile; // Cambia el perfil de postprocesamiento del volumen de postprocesamiento global al perfil proporcionado
        Debug.Log(profile.ToString());
    }
}
