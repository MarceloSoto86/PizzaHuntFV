using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{

    [SerializeField] GameObject gameObject;


    public void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(true); 
    }
}
