using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public CharController logicaPies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        logicaPies.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        logicaPies.puedoSaltar = false;
    }
}
