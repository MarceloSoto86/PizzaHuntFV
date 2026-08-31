using UnityEngine;
using System.Collections;

public class SawTraps : MonoBehaviour
{
    // Este script controla el movimiento de las sierras en la escena. Se encarga de moverlas hacia adelante y hacia atrás entre dos posiciones.
    public Transform targetPos;
    public Transform startPos;

    bool towards = true;
    public float speed = 0.1f;

    void Update()
    {
        // Si la sierra se está moviendo hacia adelante, se mueve hacia la posición objetivo. Si está cerca de la posición objetivo, cambia de dirección y se mueve hacia atrás.
        if (towards)
        {
            // Mueve la sierra hacia la posición objetivo
            transform.LookAt(targetPos.position);
            transform.position += transform.forward * speed * Time.deltaTime; // Mueve la sierra hacia adelante

            // Si la sierra está cerca de la posición objetivo, cambia de dirección y se mueve hacia atrás
            if (Vector3.Distance(transform.position, targetPos.position) < 1.0f)
            {
                towards = false; // Cambia la dirección de la sierra
            }
        }
        else
        {
            transform.LookAt(startPos.position); // Mueve la sierra hacia la posición inicial
            transform.position += transform.forward * speed * Time.deltaTime; // Mueve la sierra hacia atrás

            // Si la sierra está cerca de la posición inicial, cambia de dirección y se mueve hacia adelante
            if (Vector3.Distance(transform.position, startPos.position) < 1.0f)
            {
                {
                    towards = true; // Cambia la dirección de la sierra
                }
            }
        }
    }

}




