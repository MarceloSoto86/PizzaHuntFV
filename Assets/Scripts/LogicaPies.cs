using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    // Este script se encarga de detectar si el personaje está en contacto con el suelo para permitirle saltar.
    public CharController logicaPies;
    // Activamos la variable puedoSaltar del script CharController cuando el personaje está en contacto con el suelo y la desactivamos cuando no lo está.
    private void OnTriggerStay(Collider other)
    {
        logicaPies.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        logicaPies.puedoSaltar = false;
    }
}
