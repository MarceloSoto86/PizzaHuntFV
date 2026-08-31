using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    // Este script controla la cámara en tercera persona. Se encarga de rotar la cámara alrededor del jugador y de hacer que el jugador gire en la dirección del movimiento.
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Hacemos que el jugador gire en la dirección del movimiento
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized; // Hacemos que la orientación de la cámara siga al jugador

        float horizontalInput = Input.GetAxis("Horizontal"); // Obtenemos la entrada horizontal del usuario
        float verticalInput = Input.GetAxis("Vertical"); // Obtenemos la entrada vertical del usuario
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput; // Calculamos la dirección del movimiento en función de la entrada del usuario y la orientación de la cámara

        // Hacemos que el jugador gire en la dirección del movimiento
        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, rotationSpeed * Time.deltaTime); // Hacemos que el jugador gire suavemente en la dirección del movimiento
        }
    }
}
