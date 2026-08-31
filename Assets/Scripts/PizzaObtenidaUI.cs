using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaObtenidaUI : MonoBehaviour
{

    //NOTA: VERIFICAR SI ESTE SCRIPT HACE ALGO EXTRAÑAMENTE SIMILAR A PizzaPickUp.cs, SI ES ASÍ, ELIMINAR UNO DE LOS DOS SCRIPTS PARA EVITAR CONFLICTOS
    // Este script controla la lógica de obtención de la caja de pizza en el juego. Cuando el jugador entra en contacto con el objeto de la caja de pizza, se activa la UI correspondiente y se desactiva el objeto de la caja en el mundo del juego.
    [SerializeField] GameObject cajaDePizzaObtenida;
    [SerializeField] GameObject objetoCaja;
    [SerializeField] GameObject cajaVacia;
    public bool _isCajaObtained = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_isCajaObtained);
    }

    public void OnTriggerEnter(Collider other)
    {
        // Detecta si el jugador entra en contacto con el objeto de la caja de pizza
        if (other.gameObject.CompareTag("Player"))
        {
            cajaDePizzaObtenida.SetActive(true);
            objetoCaja.SetActive(false);
            _isCajaObtained = true;
            Debug.Log("<color=cyan>Caja De Pizza Obtenida!</color>");
            cajaVacia.SetActive(false);
        }
    }
}
