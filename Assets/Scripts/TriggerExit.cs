using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    // Esta variable se asigna en el inspector y representa el objeto que se activará cuando otro objeto entre en el trigger del objeto que tiene este script.
    [SerializeField] GameObject gameObject;

    // Este método se ejecuta cuando otro objeto entra en el trigger del objeto que tiene este script. Activa el objeto que se le asignó en el inspector.
    public void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(true); 
    }
}
