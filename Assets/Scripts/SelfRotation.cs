using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    // Variables públicas para controlar la velocidad de rotación en cada eje
    public float xRotation;
    public float yRotation;
    public float zRotation;

    // Este método se llama una vez por frame y rota el objeto en función de las velocidades de rotación definidas
    void Update()
    {
        transform.Rotate(xRotation, yRotation, zRotation);
    }
}
