using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Este script controla el movimiento del jugador y la animación del mismo.
    public Transform orientation;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float groundDrag;
    [SerializeField] float playerHeight;
    [SerializeField] Animator anim;
    [SerializeField] LayerMask whatIsGround;

    public float moveSpeed;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;
    bool grounded;

    public KeyCode jumpKey = KeyCode.Space;

    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Este método obtiene la entrada del usuario para el movimiento del jugador y el salto
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Este método permite al jugador saltar si está en el suelo y si el salto está listo
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown); // Esta línea invoca el método ResetJump después de un tiempo determinado por jumpCooldown para permitir que el jugador salte nuevamente

        }
        else
        {
            PlayerFalling(); // Esta línea invoca el método PlayerFalling para indicar que el jugador está cayendo si no está en el suelo o si el salto no está listo
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Calculamos la distancia del rayo que se utilizará para verificar si el jugador está en el suelo, teniendo en cuenta la altura del jugador y un pequeño margen adicional
        float currentRayDistance = (playerHeight*0.5f + 0.2f) * transform.localScale.y;

        // Este método verifica si el jugador está en el suelo y controla la velocidad del jugador
        grounded = Physics.Raycast(transform.position, Vector3.down, currentRayDistance, whatIsGround); // Esta línea utiliza un rayo para verificar si el jugador está en el suelo y actualiza la variable grounded en consecuencia
        MyInput(); // Esta línea invoca el método MyInput para obtener la entrada del usuario para el movimiento del jugador y el salto
        SpeedControl(); // Esta línea invoca el método SpeedControl para controlar la velocidad del jugador
        // Este bloque if establece la resistencia del jugador en función de si está en el suelo o no. Si el jugador está en el suelo, se aplica una resistencia mayor para simular la fricción con el suelo, mientras que si está en el aire, no se aplica resistencia.
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Esta línea invoca el método MovePlayer para mover al jugador en función de la entrada del usuario y la velocidad del jugador
    }

    // Este método mueve al jugador en función de la entrada del usuario y la velocidad del jugador
    private void MovePlayer()
    {
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput); // Esta línea crea un vector de movimiento en función de la entrada del usuario para el movimiento horizontal y vertical

        // Esta línea normaliza el vector de movimiento para que tenga una magnitud de 1 y se multiplica por la velocidad del jugador para obtener la velocidad final del jugador
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.2F);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        // Esta línea mueve al jugador en función del vector de movimiento y la velocidad del jugador, utilizando el espacio mundial para que el movimiento sea relativo al mundo y no a la orientación del jugador
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    // Este método controla la velocidad del jugador para que no supere la velocidad máxima establecida
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Esta línea limita la velocidad del jugador a la velocidad máxima establecida, manteniendo la velocidad vertical actual
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    // Este método permite al jugador saltar, estableciendo la velocidad vertical a cero antes de aplicar la fuerza de salto y activando la animación de salto
    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        anim.SetBool("Jump", true);
    }

    // Este método permite al jugador saltar nuevamente después de un tiempo determinado por jumpCooldown
    void ResetJump()
    {
        readyToJump = true;
    }
    // Este método se invoca cuando el jugador está cayendo, desactivando las animaciones de salto y suelo
    void PlayerFalling()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Grounded", false);
        //readyToJump = false;
    }
}
