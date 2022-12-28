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
            cocaObtenida.SetActive(true);
            objetoCoca.SetActive(false);
            _isCocaObtained = true;
            Debug.Log("Coca Obtenida!");
            cocaVacia.SetActive(false);
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
    