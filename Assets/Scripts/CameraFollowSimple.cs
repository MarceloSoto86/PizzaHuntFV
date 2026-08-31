using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    // Esta clase hace que la cámara siga al jugador con un desplazamiento y suavizado.
    // La cámara se mueve hacia la posición del jugador más un desplazamiento definido, y puede mirar al jugador si se activa la opción.
    
    public Transform player;
    public Vector3 cameraOffset; // La variable cameraOffset define el desplazamiento de la cámara con respecto al jugador.
    public float smoothFactor = 0.5f; // La variable smoothFactor controla la suavidad del movimiento de la cámara.
    bool lookAtTarget = false; // La variable lookAtTarget determina si la cámara debe mirar al jugador.
    void Start()
    {
        // Inicializa el desplazamiento de la cámara con respecto al jugador.
        cameraOffset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Calcula la nueva posición de la cámara sumando el desplazamiento al jugador.
        Vector3 newPosition = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor); // Mueve la cámara suavemente hacia la nueva posición usando Slerp para interpolación esférica.
        // Si lookAtTarget es verdadero, la cámara mirará al jugador.
        if (lookAtTarget)
        {
            transform.LookAt(player);
        }
    }
}
