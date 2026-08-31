using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    // Este script controla el movimiento del personaje y la animación del mismo.
    // El personaje se mueve en función de la entrada del usuario y se anima en consecuencia.

    private new Rigidbody rb;
    public float movementSpeed;
    public float fuerzaDeSalto = 8f;
    public float jumpCooldown;
    public float airMultiplier;

    public float groundDrag; // Gravedad que se aplica al personaje cuando está en el suelo
    public float playerHeight; // Altura del personaje
    public float velocidadRotacion = 200.0f;
    public bool puedoSaltar;

    public float x, y; // Variables para el movimiento del personaje en el eje X y Y

    //Variables animación

    private Animator playerAnimController;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos el Rigidbody del personaje y la variable puedoSaltar
        rb = GetComponent<Rigidbody>();
        puedoSaltar = false;
        playerAnimController = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Obtenemos la entrada del usuario para el movimiento del personaje
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero; // Inicializamos la velocidad del personaje a cero

        // Si el personaje se está moviendo, calculamos la dirección del movimiento y la velocidad
        if (hor != 0 || ver != 0)
        {
            // Calculamos la dirección del movimiento en función de la entrada del usuario y la orientación del personaje
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
            // Calculamos la velocidad del personaje en función de la dirección del movimiento y la velocidad de movimiento
            velocity = direction * movementSpeed;
            playerAnimController.SetFloat("PlayerWalkVelocity", movementSpeed); //Comentar si no funciona porque es con otras variables que no están en este script
        }

        // Aplicamos la velocidad calculada al Rigidbody del personaje, manteniendo la velocidad vertical actual
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;

        // Rotamos el personaje en función de la entrada del usuario y la velocidad de rotación
        transform.Rotate(0, hor * Time.deltaTime * velocidadRotacion, 0);
        //playerAnimController.SetFloat("PlayerVerticalVelocity", velocity.y);

        // Comprobamos si el personaje puede saltar y aplicamos la fuerza de salto si se presiona la tecla de salto
        if (puedoSaltar)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimController.SetBool("salte",true) ;
                rb.AddForce(new Vector3(0,fuerzaDeSalto,0),ForceMode.Impulse); // Aplicamos la fuerza de salto al Rigidbody del personaje
            }
            playerAnimController.SetBool("IsGrounded", true); // Si el personaje puede saltar, significa que está en el suelo
        }
        else
        {
            EstoyCayendo(); // Si el personaje no puede saltar, significa que está en el aire
        }
    }

    // Función que se llama cuando el personaje está cayendo
    public void EstoyCayendo()
    {
        // Si el personaje no puede saltar, significa que está en el aire
        playerAnimController.SetBool("IsGrounded", false);
        playerAnimController.SetBool("salte", false); 
    }
}
