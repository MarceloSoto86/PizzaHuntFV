using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesEnEscena : MonoBehaviour
{
    // Este script se encarga de mantener el objeto "OpcionesEnEscena" entre escenas y evitar duplicados.
    private void Awake()
    {

        //Al entrar en nueva escena busca el objeto OpcionesEnEscena y si encuentra, destruye el objeto para que no haya duplicados
        var noDestruirEntreEscenas = FindObjectsOfType<OpcionesEnEscena>();
        // Si hay más de un objeto OpcionesEnEscena, destruye el objeto actual y sale del método
        if (noDestruirEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }
}
