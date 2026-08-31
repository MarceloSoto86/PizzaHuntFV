using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickUp : MonoBehaviour
{
    // Este script se encarga de detectar cuándo el jugador entra en contacto con la caja de pizza y activar la pizza en el inventario del jugador, así como activar la rotación del molino.
    [SerializeField] GameObject player;
    [SerializeField] GameObject pizza;
    [SerializeField] GameObject mill;
    [SerializeField] float millRotationSpeed = -0.09f; // Velocidad de rotación del molino

    // Este método se ejecuta cuando el jugador entra en contacto con la caja de pizza
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra en contacto con la caja de pizza es el jugador, se activa la pizza en el inventario del jugador y se activa la rotación del molino
        if (other.gameObject.CompareTag("Player"))
        {
            pizza = player.transform.GetChild(1).GetChild(0).gameObject;
            mill.GetComponent<SelfRotation>().zRotation = millRotationSpeed;
            pizza.SetActive(true);
            Destroy(gameObject);
            Debug.Log("<color=cyan>Caja de Pizza Obtenida! Camino a la salida activado!</color>");
        }
    }
}
