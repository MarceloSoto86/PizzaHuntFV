using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPauseMenu : MonoBehaviour
{
    //  Esta variable estática permite que otras clases puedan acceder a ella para saber si el menú de opciones está activo o no.
    public static bool isOptionsActive = true;
    [SerializeField] GameObject optionsMenu;

    // Update is called once per frame
    void Update()
    {
        // Este código permite cerrar el menú de opciones al presionar la tecla Escape, siempre y cuando el menú de opciones esté activo.
        if (Input.GetKeyDown(KeyCode.Escape))
        { optionsMenu.SetActive(false); }
    }
}
