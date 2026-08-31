using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthPoints : MonoBehaviour
{

    public int health; // Variable que representa la cantidad de vida del jugador
    public int sawDamage = 1; // Variable que representa la cantidad de daño que recibe el jugador al tocar una sierra
    public int numOfPizzas = 5; // Variable que representa el número de pizzas que tiene el jugador
    public Image[] pizzas; // Array de imágenes que representan las pizzas del jugador
    public Sprite fullPizza; // Sprite que representa una pizza completa
    public Sprite emptyPizza; // Sprite que representa una pizza vacía
    public bool invencible = false; // Variable que indica si el jugador es invencible
    public float tiempo_invencible = 1f; // Variable que representa el tiempo que el jugador permanece invencible
    public float tiempo_frenado = 0.2f; // Variable que representa el tiempo que el jugador permanece frenado

    public event EventHandler MuerteJugador; // Evento que se dispara cuando el jugador muere

    private Animator playerAnimController; // Variable que representa el controlador de animaciones del jugador

    // Este start inicializa la cantidad de pizzas que tiene el jugador y la cantidad de vida que tiene el jugador
    public void Start()
    {
        numOfPizzas = health / sawDamage;
        health = numOfPizzas;
    }

    // Este update actualiza la cantidad de pizzas que tiene el jugador y la cantidad de vida que tiene el jugador
    private void Update()
    {
        for (int i = 0; i < pizzas.Length; i++) // Recorre el array de imágenes de pizzas
        {
            if (i < health) // Si el índice es menor que la cantidad de vida del jugador, se muestra una pizza completa
            {
                pizzas[i].sprite = fullPizza; // Si el índice es menor que la cantidad de vida del jugador, se muestra una pizza completa
            }
            else
            {
                pizzas[i].sprite = emptyPizza; // Si el índice es mayor o igual que la cantidad de vida del jugador, se muestra una pizza vacía
            }

            if (i < numOfPizzas)
            {
                pizzas[i].enabled = true; // Si el índice es menor que el número de pizzas, se habilita la imagen de la pizza
            }
            else
            {
                pizzas[i].enabled = false; // Si el índice es mayor o igual que el número de pizzas, se deshabilita la imagen de la pizza
            }
        }
    }

    // Este método resta vida al jugador y dispara el evento de muerte si la vida llega a cero
    public void RestarVida(int cantidad)
    {
        if (!invencible && health > 0) // Si el jugador no es invencible y tiene vida, se resta vida
        { 
            health -= cantidad; // Se resta la cantidad de vida al jugador
            StartCoroutine(Invulnerabilidad()); // Se inicia la corrutina de invulnerabilidad
            StartCoroutine(FrenarVelocidad()); // Se inicia la corrutina de frenado de velocidad
            if (health <= 0) // Si la vida del jugador llega a cero, se dispara el evento de muerte
            {
                Debug.Log("<color=red>HEALTH REACHED 0: Disparando evento MuerteJugador</color>");
                MuerteJugador?.Invoke(this, EventArgs.Empty); // Se dispara el evento de muerte
                Time.timeScale = 0f; // Se pausa el juego
            }
        }
    }

    // Este método activa la invulnerabilidad del jugador durante un tiempo determinado
    IEnumerator Invulnerabilidad()
    {
        invencible = true; // Se activa la invulnerabilidad
        yield return new WaitForSeconds(tiempo_invencible); // Se espera el tiempo de invulnerabilidad
        invencible = false; // Se desactiva la invulnerabilidad
    }

    // Este método frena la velocidad del jugador durante un tiempo determinado
    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<PlayerMovement>().moveSpeed; // Se guarda la velocidad actual del jugador
        GetComponent<PlayerMovement>().moveSpeed = 0;   // Se frena la velocidad del jugador
        yield return new WaitForSeconds(tiempo_frenado); // Se espera el tiempo de frenado
        GetComponent<PlayerMovement>().moveSpeed = velocidadActual; // Se restaura la velocidad del jugador
    }
}

