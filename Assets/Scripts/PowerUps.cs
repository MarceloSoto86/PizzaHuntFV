using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PowerUps : MonoBehaviour
{
    // Este script controla los power-ups que el jugador puede recoger en el juego. Dependiendo del tipo de power-up, se aplican diferentes efectos al jugador durante un tiempo determinado.
    public GameObject Player;
    [SerializeField] float powerTime = 10f;
    [SerializeField] int powerType = 0;
    //[SerializeField] PostProcessProfile profile; // Variable para el perfil de postprocesamiento que se aplicará al recoger el power-up
    [SerializeField] GameObject PostProController; // Variable para el objeto que controla el postprocesamiento en la escena
    //[SerializeField] private PostProcessVolume  _postProcessVolume; // Variable para el volumen de postprocesamiento que se aplicará al recoger el power-up

    [Header("Post Processing URP")]
    [SerializeField] private VolumeProfile powerUpProfile; // Asset del PowerUp
    [SerializeField] private VolumeProfile defaultProfile; // Asset normal del nivel
    [SerializeField] private Volume sceneVolume;          // Componente Volume en escena

    bool isPowered = false;
    Vector3 originalScale;

    void Update()
    {
        // Si el power-up está activo, se reduce el tiempo restante del efecto
        if (isPowered)
        {
            powerTime -= Time.deltaTime;
        }

        // Cuando el tiempo del power-up llega a cero, se desactiva el efecto y se destruye el objeto del power-up
        if (powerTime <= 0.0f)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false; // Desactiva el MeshRenderer del objeto hijo del power-up
            timerEnded(); // Llama a la función que desactiva el efecto del power-up
            Destroy(gameObject);
        }
    }

    private void ApplyURPEffect()
    {
        if (sceneVolume != null && powerUpProfile != null)
        {
            // Cambiamos el perfil asignado al Volume global
            sceneVolume.profile = powerUpProfile;
            //sceneVolume.isGlobal = true;
            //sceneVolume.weight = 1f;
        }
    }

    private void RemoveURPEffect()
    {
        if (sceneVolume != null && defaultProfile != null)
        {
            sceneVolume.profile = defaultProfile;
            //sceneVolume.isGlobal = false;
            //sceneVolume.weight = 0f;
        }
    }

    // Este método se ejecuta cuando el jugador entra en contacto con el power-up. Dependiendo del tipo de power-up, se aplican diferentes efectos al jugador.
    public void OnTriggerEnter(Collider other)
    {
        // Si el objeto que colisiona con el power-up es el jugador, se aplican los efectos del power-up
        if (other.gameObject.CompareTag("Player"))
        {
            // Guardamos la escala original del jugador antes de aplicar el efecto del power-up
            originalScale = other.transform.localScale; // Guardamos la escala original del jugador antes de aplicar el efecto del power-up
            //PostProController.GetComponent<PostProController>().ChangeProfile(profile); // Cambia el perfil de postprocesamiento al recoger el power-up
            gameObject.GetComponent<MeshRenderer>().enabled = false; // Desactiva el MeshRenderer del power-up para que no sea visible después de recogerlo
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false; // Desactiva el MeshRenderer del objeto hijo del power-up para que no sea visible después de recogerlo

            // Dependiendo del tipo de power-up, se aplican diferentes efectos al jugador
            if (powerType == 0) // Código de power-up GIGANTE
            {
                isPowered = true; // Activamos el efecto del power-up
                other.transform.localScale = Vector3.Scale(Vector3.one, new Vector3(originalScale.x +1, originalScale.y + 1, originalScale.z + 1)); // Aumentamos la escala del jugador en 1 unidad en cada eje
                Debug.Log("<color=magenta>It's so BIG!</color>");

                gameObject.GetComponent<Renderer>().enabled = false; // Desactiva el MeshRenderer del power-up para que no sea visible después de recogerlo

            }

            // Dependiendo del tipo de power-up, se aplican diferentes efectos al jugador
            if (powerType == 1) // Código de power-up PEQUEÑO
            {
                isPowered = true; // Activamos el efecto del power-up
                other.transform.localScale = Vector3.Scale(Vector3.one, new Vector3(originalScale.x -0.8f, originalScale.y -0.8f, originalScale.z -0.8f)); // Disminuimos la escala del jugador en 0.8 unidades en cada eje
                Debug.Log("<color=magenta>Ok, so basically im very smol</color>");

                gameObject.GetComponent<Renderer>().enabled = false; // Desactiva el MeshRenderer del power-up para que no sea visible después de recogerlo
            }

            // Dependiendo del tipo de power-up, se aplican diferentes efectos al jugador
            if (powerType == 2) // Código de power-up SUPER SALTO
            {
                isPowered = true; // Activamos el efecto del power-up
                other.GetComponentInChildren<PlayerMovement>().jumpForce = 10f; // Aumentamos la fuerza de salto del jugador a 10 unidades
                Debug.Log("<color=magenta>Gave my love to a shooting star :'( </color>");
                gameObject.GetComponent<MeshRenderer>().enabled = false; // Desactiva el MeshRenderer del power-up para que no sea visible después de recogerlo
                
                ApplyURPEffect(); // Activamos el efecto de postprocesamiento URP
            }

            Player = other.gameObject; // Guardamos la referencia al jugador que recogió el power-up
        }
    }

    // Este método se ejecuta cuando el tiempo del power-up llega a cero. Se desactiva el efecto del power-up y se restaura la escala original del jugador.
    void timerEnded()
    {
        Debug.Log("Time ended!");
        Player.transform.localScale = originalScale; // Restauramos la escala original del jugador
        Player.GetComponentInChildren<PlayerMovement>().jumpForce = 5f; // Restauramos la fuerza de salto original del jugador
        RemoveURPEffect(); // Desactivamos el efecto de postprocesamiento URP
    }
}
