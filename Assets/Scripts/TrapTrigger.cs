using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    // Este script se encarga de activar o desactivar trampas cuando el jugador entra en un trigger. Se utiliza para controlar la activación de trampas en el juego.
    [SerializeField] GameObject[] targetTraps;
    
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra en el trigger tiene la etiqueta "Player", se activa o desactiva las trampas objetivo.
        if (other.gameObject.CompareTag("Player"))
        {
            // Se recorre el array de trampas objetivo y se activa o desactiva cada una según su estado actual.
            foreach (var trap in targetTraps)
            {
                // Si la trampa no está activa, se activa y se imprime un mensaje en la consola. Si ya está activa, se desactiva.
                if (!trap.activeSelf)
                {
                    Debug.Log("triggered");
                    trap.SetActive(true);
                }
                else trap.SetActive(false);
            }
        }
    }
}
