using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesEnEscena : MonoBehaviour
{


    private void Awake()
    {

        //Al entrar en nueva escena busca el objeto OpcionesEnEscena y si encuentra, destruye el objeto para que no haya duplicados
        var noDestruirEntreEscenas = FindObjectsOfType<OpcionesEnEscena>();
        if (noDestruirEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
