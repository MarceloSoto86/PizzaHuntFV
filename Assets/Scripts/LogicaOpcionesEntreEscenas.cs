using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOpcionesEntreEscenas : MonoBehaviour
{
    public ControladorOpciones panelOpciones;
    // Start is called before the first frame update
    void Start()
    {
        // Cuándo inicia la escena busca y obtiene "ControladorOpciones" mediante el tag "Opciones" para pasarla de una escena a otra. Esto permite activar el panel "pantallaOpciones" cuándo se desee
        panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorOpciones>();
    }

    // Activa el panel al presionar la tecla Escape que ejecuta el método MostrarOpciones
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MostrarOpciones();
        }
        
        
    }


    // Activa el panel de opciones
    public void MostrarOpciones()
    {
        panelOpciones.pantallaOpciones.SetActive(true);
    }
}
