using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] targetTraps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var trap in targetTraps)
            {
                if (!trap.activeSelf)
                {
                    Debug.Log("triggered");
                    trap.SetActive(true);
                }
                else trap.SetActive(false);
            }
        }
    }
}
