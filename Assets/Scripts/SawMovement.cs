using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SawMovement : MonoBehaviour
{
    // This script controls the movement of a saw object in the game. It allows the saw to move in a specified direction at a specified speed and destroys it after a certain time.
    [SerializeField] float _speed;
    private Vector2 moveDirection;
    
    void Update()
    {
        // Move the saw in the specified direction at the specified speed
        transform.Translate(moveDirection * _speed * Time.deltaTime);
        Destroy(gameObject, 5f );
    }

    // This method sets the direction in which the saw will move. It takes a Vector2 parameter that specifies the direction.
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
}
