using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUps : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] float powerTime = 10f;
    [SerializeField] int powerType = 0;
    bool isPowered = false;

    void Update()
    {
        if (isPowered)
        {
            powerTime -= Time.deltaTime;
        }
        if (powerTime <= 0.0f)
        {
            timerEnded();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (powerType == 0) // Código de power-up GIGANTE
        {
            isPowered = true;
            other.transform.localScale = Vector3.Scale(Vector3.one, new Vector3(2f, 2f, 2f));
            Debug.Log("It's so big!");

            gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (powerType == 1) // Código de power-up PEQUEÑO
        {
            isPowered = true;
            other.transform.localScale = Vector3.Scale(Vector3.one, new Vector3(0.1f, 0.1f, 0.1f));
            Debug.Log("Ok, so basically im very smol");

            gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (powerType == 2) // Código de power-up SUPER SALTO
        {
            isPowered = true;
            other.GetComponentInChildren<CharController>().fuerzaDeSalto = 10f;
            //other.GetComponentInChildren<PlayerMovement>().JumpHeight = 3f;
            Debug.Log("Gave my love to a shooting star :'(");

            gameObject.GetComponent<Renderer>().enabled = false;
        }

    }
    void timerEnded()
    {
        Debug.Log("Time ended!");
        Player.transform.localScale = Vector3.Scale(Vector3.one, new Vector3(1f, 1f, 1f));
        Player.GetComponentInChildren<CharController>().fuerzaDeSalto = 5f;
        //Player.GetComponentInChildren<PlayerMovement>().JumpHeight = 1.2f;
    }

}
