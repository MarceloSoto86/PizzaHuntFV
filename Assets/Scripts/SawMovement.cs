using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SawMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    private Vector2 moveDirection;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * _speed * Time.deltaTime);
            Destroy(gameObject, 5f );
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
}
