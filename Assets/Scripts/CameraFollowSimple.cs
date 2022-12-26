using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    bool lookAtTarget = false;
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        if (lookAtTarget)
        {
            transform.LookAt(player);
        }

        /*if (player = null)
        {
            transform.LookAt(newPosition);
        }
        else transform.LookAt(newPosition);*/
    }
}
