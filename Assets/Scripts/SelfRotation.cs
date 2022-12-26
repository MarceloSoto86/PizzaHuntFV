using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float xRotation;
    public float yRotation;
    public float zRotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotation, yRotation, zRotation);
    }
}
