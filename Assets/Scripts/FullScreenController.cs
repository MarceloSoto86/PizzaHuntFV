using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreenController : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolucionesDropDown;
    Resolution[] resoluciones;

    // El bloque de Start se ejecuta al inicio del juego y establece el estado del toggle según si la pantalla está en modo completo o no, y llama a la función RevisarResolucion para actualizar las opciones del dropdown de resoluciones.
    // Start is called before the first frame update
    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        RevisarResolucion();
    }

    // Activar o desactivar el modo de pantalla completa según el estado del toggle
    public void ActivarFullScreen(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    // Revisar las resoluciones disponibles y establecer la resolución actual en el dropdown
    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions; // Obtener las resoluciones disponibles en el dispositivo
        resolucionesDropDown.ClearOptions(); // Limpiar las opciones del dropdown
        List<string> opciones = new List<string>(); // Crear una lista de opciones para el dropdown
        int resolucionActual = 0; // Variable para almacenar el índice de la resolución actual

        // Agregar las resoluciones disponibles al dropdown
        for (int i=0; i<resoluciones.Length; i++)
        {
            // Crear una cadena de texto con la resolución en formato "Ancho x Alto"
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            opciones.Add(opcion); // Agregar la opción al dropdown

            // Revisar si la resolución actual es igual a la resolución de pantalla completa
            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolucionesDropDown.AddOptions(opciones); // Agregar las opciones al dropdown
        resolucionesDropDown.value = resolucionActual; // Establecer la resolución actual como la opción seleccionada
        resolucionesDropDown.RefreshShownValue(); // Actualizar el valor mostrado en el dropdown
        resolucionesDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0); // Establecer la resolución guardada en PlayerPrefs como la opción seleccionada
    }
    // Cambiar la resolución de pantalla según la opción seleccionada en el dropdown
    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropDown.value); // Guardar la opción seleccionada en PlayerPrefs
        Resolution resolucion = resoluciones[indiceResolucion]; // Obtener la resolución seleccionada
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen); // Establecer la resolución de pantalla
    }
  
}
