using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    // Este script se encarga de hacer daño al jugador cuando entra en contacto con un objeto que tenga este script adjunto.
    public int cantidad = 1;

    // Este método se llama cuando el jugador entra en contacto con el objeto que tiene este script adjunto.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Comprueba si el objeto que ha entrado en contacto con el objeto que tiene este script adjunto tiene la etiqueta "Player".
        {
            other.GetComponent<HealthPoints>().RestarVida(cantidad); // Llama al método RestarVida del script HealthPoints del jugador y le pasa la cantidad de daño a hacer.
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Comprueba si el objeto que ha entrado en contacto con el objeto que tiene este script adjunto tiene la etiqueta "Player".
        {
            other.GetComponent<HealthPoints>().RestarVida(cantidad); // Llama al método RestarVida del script HealthPoints del jugador y le pasa la cantidad de daño a hacer.
        }
    }



}
