using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickUp : MonoBehaviour
{
    public GameObject player;
    private GameObject pizza;

    private void OnTriggerEnter(Collider other)
    {
        pizza = player.transform.GetChild(1).GetChild(0).gameObject;
        pizza.SetActive(true);
        Destroy(gameObject);
        
    }
}
