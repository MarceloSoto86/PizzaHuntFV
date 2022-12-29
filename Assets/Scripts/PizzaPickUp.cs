using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickUp : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject pizza;
    [SerializeField] GameObject mill;
    [SerializeField] float millRotationSpeed = -0.09f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pizza = player.transform.GetChild(1).GetChild(0).gameObject;
            mill.GetComponent<SelfRotation>().zRotation = millRotationSpeed;
            pizza.SetActive(true);
            Destroy(gameObject);
            Debug.Log("Caja de Pizza Obtenida! Camino a la salida activado!");
        }
    }
}
