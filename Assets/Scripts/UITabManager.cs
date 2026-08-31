using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabManager : MonoBehaviour
{
    // Este script controla la activación y desactivación de los tabs en la interfaz de usuario. Se encarga de activar el tab seleccionado y desactivar los demás.
    [SerializeField] private GameObject[] tabs;

    // Este método se ejecuta cuando se selecciona un tab y activa el tab seleccionado mientras desactiva los demás.
    public void onTabSwitch(GameObject tab)
    { tab.SetActive(true);
        // Recorre el array de tabs y desactiva los que no son el tab seleccionado
        for (int i = 0; i < tabs.Length; i++)
        // Si el tab actual no es el tab seleccionado, se desactiva
        {
            if (tabs[i] != tab)
            { tabs[i].SetActive(false); }
        }    
    
    }
}
