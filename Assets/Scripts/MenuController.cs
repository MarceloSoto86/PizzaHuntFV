using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    // Variables para controlar el volumen del juego y la pantalla de confirmación
    [Header("Opciones de volumen")]
    [SerializeField] private Text volumeTextValue = null; // Variable para mostrar el valor del volumen en la interfaz de usuario
    [SerializeField] private Slider volumeSlider = null; // Variable para controlar el valor del volumen mediante un slider en la interfaz de usuario
    [SerializeField] private float defaultVolume = 0.5f; // Variable para almacenar el volumen por defecto
    [SerializeField] private GameObject confirmationPrompt = null; // Variable para mostrar la pantalla de confirmación al aplicar cambios en el volumen

    // Variables para controlar la carga de niveles y la pantalla de diálogo de juego guardado
    [Header("Niveles a cargar")] 
    public string _newGameLevel; // Variable para almacenar el nombre del nivel a cargar al iniciar un nuevo juego
    private string levelToLoad; // Variable para almacenar el nombre del nivel a cargar al cargar un juego guardado
    [SerializeField] private GameObject noSavedGameDialog = null; // Variable para mostrar la pantalla de diálogo cuando no hay un juego guardado

    // Método para iniciar un nuevo juego y cargar el nivel correspondiente
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    // Método para cargar un juego guardado y cargar el nivel correspondiente
    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel")) // Verifica si existe un juego guardado
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel"); // Obtiene el nombre del nivel guardado en PlayerPrefs
            SceneManager.LoadScene(levelToLoad); // Carga el nivel correspondiente al juego guardado
        }
        else
        {
            noSavedGameDialog.SetActive(true); // Muestra la pantalla de diálogo cuando no hay un juego guardado
        }
    }

    // Método para salir del juego
    public void ExitButton()
    {
        Application.Quit();
    }

    // Método para establecer el volumen del juego y actualizar la interfaz de usuario
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Establece el volumen del juego
        volumeTextValue.text = volume.ToString("0.0"); // Actualiza el valor del volumen en la interfaz de usuario
    }

    // Método para aplicar los cambios en el volumen y mostrar la pantalla de confirmación
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume); // Guarda el volumen en PlayerPrefs
        //Mostrar una pantalla
        StartCoroutine(ConfirmationBox());
    }

    // Método para restablecer el volumen a su valor por defecto y actualizar la interfaz de usuario
    public void BotonReset(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume; // Restablece el volumen al valor por defecto
            volumeSlider.value = defaultVolume; // Actualiza el valor del slider en la interfaz de usuario
            volumeTextValue.text = defaultVolume.ToString("0.0"); // Actualiza el valor del texto en la interfaz de usuario
            VolumeApply(); // Aplica los cambios en el volumen y muestra la pantalla de confirmación
        }
    }

    // Corrutina para mostrar la pantalla de confirmación durante un tiempo determinado
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true); // Muestra la pantalla de confirmación
        yield return new WaitForSeconds(2); // Espera durante 2 segundos
        confirmationPrompt.SetActive(false); // Oculta la pantalla de confirmación
    }
}
