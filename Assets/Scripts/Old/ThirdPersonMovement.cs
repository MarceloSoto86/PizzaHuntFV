using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 280.0f;
    public float jumpForce = 3.0f;

    float horizontal;
    float vertical;

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;

        Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);
        //Quaternion rotationToMoveDirection = Quaternion.LookRotation(moveDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToCamera, rotationSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMoveDirection, rotationSpeed * Time.deltaTime);


        moveDirection = rotationToCamera * moveDirection;

        transform.position += moveDirection * speed * Time.deltaTime;
    }
    public void OnMoveInput(float horizontal, float vertical)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
        Debug.Log($"{ horizontal}, { vertical}");
    }
 
}
