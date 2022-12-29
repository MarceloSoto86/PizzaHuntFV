using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaObtenidaUI : MonoBehaviour
{
    [SerializeField] GameObject cajaDePizzaObtenida;
    [SerializeField] GameObject objetoCaja;
    [SerializeField] GameObject cajaVacia;
    public bool _isCajaObtained = false;









    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_isCajaObtained);




    }

    private void Update()
    {
        /*if (!_isCocaObtained)
        {
            mostrarCocaVacia();

        }
        else
        {
            mostrarCocaLlena();
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        //other.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Player"))
        {
            cajaDePizzaObtenida.SetActive(true);
            objetoCaja.SetActive(false);
            _isCajaObtained = true;
            Debug.Log("Caja De Pizza Obtenida!");
            cajaVacia.SetActive(false);
        }
        /*        Time.timeScale = 0;*/

    }

    /*public void mostrarCocaVacia()
    {
        cocaVacia.SetActive(true);
        //* Time.timeScale = 1f;*//*
        _isCocaObtained = false;
    }*/

    /* public void mostrarCocaLlena()
     {

         cocaObtenida.SetActive(true);
         //*Time.timeScale = 0f;*/ /*Revisar el Player*//*
         _isCocaObtained = true;
     }
 */
}
