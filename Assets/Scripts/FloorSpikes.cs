using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikes : MonoBehaviour
{
    // Este script hace que las puntas del piso se muevan hacia arriba y hacia abajo de manera oscilante.
    public float speed = 1f;
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 2.24f - 1.12f; // Oscila entre -1.12 y 1.12 y lo que hace es que las puntas del piso se muevan hacia arriba y hacia abajo de manera oscilante.
        transform.position = new Vector3(transform.position.x, y, transform.position.z); // Actualiza la posición de las puntas del piso en el eje Y.
    }
}
