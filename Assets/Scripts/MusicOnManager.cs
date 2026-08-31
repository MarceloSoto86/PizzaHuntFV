using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnManager : MonoBehaviour
{
    // Este script controla el estado del sonido en el juego, permitiendo al jugador activar o desactivar el sonido y guardar su preferencia entre sesiones.
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;   
    private bool muted = false;


    // Start is called before the first frame update
    void Start()
    {
        // Si no existe la clave "muted" en PlayerPrefs, se crea y se carga el valor por defecto (0 = sonido activado)
        if (!PlayerPrefs.HasKey("muted"))
        {
            // Si no existe la clave "muted", se establece el valor por defecto en 0 (sonido activado) y se guarda en PlayerPrefs
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        UpdateButtonIcon(); // Actualiza el icono del botón de sonido según el estado actual (activado o desactivado)

        AudioListener.pause = muted; // Pausa o reanuda el audio según el estado de "muted"
    }

    // Este método se llama cuando se presiona el botón de sonido en la interfaz de usuario
    public void OnButtonPress()
    {
        // Cambia el estado de "muted" y pausa o reanuda el audio según corresponda
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save(); // Guarda el estado actual de "muted" en PlayerPrefs para que se mantenga entre sesiones
        UpdateButtonIcon(); // Actualiza el icono del botón de sonido según el nuevo estado (activado o desactivado)
    }

    // Este método actualiza el icono del botón de sonido según el estado actual de "muted"
    private void UpdateButtonIcon()
    {
        // Si el sonido está activado, se muestra el icono de sonido activado y se oculta el icono de sonido desactivado
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }

        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    // Este método carga el estado de "muted" desde PlayerPrefs al iniciar el juego
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    // Este método guarda el estado de "muted" en PlayerPrefs para que se mantenga entre sesiones
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    
}
