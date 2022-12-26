using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikes : MonoBehaviour
{
    public float speed = 1f;
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 2.24f - 1.12f;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
