using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicQualityController : MonoBehaviour
{
    // Estas variables se pueden configurar desde el inspector de Unity y corresponden a los elementos de la interfaz de usuario que permiten al jugador seleccionar la calidad gráfica del juego.
    public TMP_Dropdown dropdown;
    public int quality;

    // Este método se llama al inicio del juego y se encarga de inicializar la calidad gráfica del juego según la configuración guardada en PlayerPrefs. Si no hay una configuración guardada, se establece un valor predeterminado.
    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("numeroCalidad", 3);
        dropdown.value = quality;
        AjustarCalidad(); // Llamada al método para ajustar la calidad gráfica según la configuración guardada
    }

    // Este método se llama cuando el jugador cambia la selección en el dropdown de calidad gráfica. Ajusta la calidad gráfica del juego según la selección del jugador y guarda la configuración en PlayerPrefs para que se mantenga entre sesiones de juego.
    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value); // Ajusta la calidad gráfica del juego según el valor seleccionado en el dropdown
        PlayerPrefs.SetInt("numeroCalidad",dropdown.value); // Guarda la configuración de calidad gráfica en PlayerPrefs para que se mantenga entre sesiones de juego
        quality = dropdown.value; // Actualiza la variable quality con el valor seleccionado en el dropdown
    }
}
