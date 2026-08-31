using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CocaController : MonoBehaviour
{
    [SerializeField] GameObject cocaObtenida;
    [SerializeField] GameObject objetoCoca;
    [SerializeField] GameObject cocaVacia;
    public bool _isCocaObtained = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_isCocaObtained);
    }

    public void OnTriggerEnter(Collider other)
    {
        // Este bloque de código se ejecutará cuando el jugador entre en contacto con el objeto de la cocaína.
        if (other.gameObject.CompareTag("Player"))
        {
            cocaObtenida.SetActive(true); // Mostrar el mensaje de que la cocaína ha sido obtenida.
            objetoCoca.SetActive(false); // Desactivar el objeto de la cocaína en la escena.
            _isCocaObtained = true; // Actualizar la variable para indicar que la cocaína ha sido obtenida.
            Debug.Log("Coca Obtenida!");
            cocaVacia.SetActive(false); // Desactivar el objeto de la cocaína vacía en la escena.
        }
    }
}
    