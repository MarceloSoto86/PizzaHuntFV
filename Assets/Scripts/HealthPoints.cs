using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthPoints : MonoBehaviour
{

    public int health;
    public int sawDamage = 1;
    public int numOfPizzas = 5;
    public Image[] pizzas;
    public Sprite fullPizza;
    public Sprite emptyPizza;
    /*public int playerHealth = 5;*/
    public bool invencible = false;
    public float tiempo_invencible = 1f;
    public float tiempo_frenado = 0.2f;
    //private CharController _player;

    //public GameOverController script;
    public event EventHandler MuerteJugador;

    /*public Animator animDeath;*/
    private Animator playerAnimController;

    public void Start()
    {
        numOfPizzas = health / sawDamage;
        health = numOfPizzas;
        //playerAnimController = GetComponent<Animator>();
    }

    private void Update()
    {
        

        for (int i = 0; i < pizzas.Length; i++)
        {
            if (i < health)
            {
                pizzas[i].sprite = fullPizza;
            }
            else
            {
                pizzas[i].sprite = emptyPizza;
            }

            if (i < numOfPizzas)
            {
                pizzas[i].enabled = true;
            }
            else
            {
                pizzas[i].enabled = false;
            }
        }
    }

    public void RestarVida(int cantidad)
    {
        if (!invencible && health > 0)
        { 
            health -= cantidad;
            //playerAnimController.Play("Damage");
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
            if (health <= 0)
            {


                /*   if (health <= 0)
                   {*/
                MuerteJugador?.Invoke(this, EventArgs.Empty);

                
                //Time.timeScale = 0;
                
                //    Destroy(gameObject);



                //Estamos muertos
                //Activar animación muerte (activar en variables arriba la línea de código para el animator)
                // animDeath.SetBool("IsDead",true);
                //Activar GameOver screen
                /*script.SetGameOver();*/
                /* }*/
                //script.SetGameOver();
            }
        }
    }


    IEnumerator Invulnerabilidad()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invencible = false;
    }

    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<PlayerMovement>().moveSpeed;
        GetComponent<PlayerMovement>().moveSpeed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<PlayerMovement>().moveSpeed = velocidadActual;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Saw"))
        {
            playerHealth -= sawDamage;

        }
    }*/
}

