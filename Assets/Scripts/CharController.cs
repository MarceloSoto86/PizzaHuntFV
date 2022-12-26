using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    
    private new Rigidbody rb;
    public float movementSpeed;
    public float fuerzaDeSalto = 8f;
    public float jumpCooldown;
    public float airMultiplier;

    public float groundDrag;
    public float playerHeight;
    public bool puedoSaltar;
    public float velocidadRotacion = 200.0f;
    
    public float x, y;

    //Variables animación

    private Animator playerAnimController;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puedoSaltar = false;
        playerAnimController = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;



        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;

            velocity = direction * movementSpeed;
            playerAnimController.SetFloat("PlayerWalkVelocity", movementSpeed); //Comentar si no funciona porque es con otras variables que no están en este script
        }

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        transform.Rotate(0, hor * Time.deltaTime * velocidadRotacion, 0);
        //playerAnimController.SetFloat("PlayerVerticalVelocity", velocity.y);

        


        if (puedoSaltar)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimController.SetBool("salte",true) ;
                rb.AddForce(new Vector3(0,fuerzaDeSalto,0),ForceMode.Impulse);
            }
            playerAnimController.SetBool("IsGrounded", true);
        }
        else
        {
            EstoyCayendo();
        }


        



    }

    public void EstoyCayendo()
    {
        playerAnimController.SetBool("IsGrounded", false);
        playerAnimController.SetBool("salte", false);
        
    }

    

    private void OnAnimatorMove()
    {
        
    }



    /*  //Funcion para la gravedad.

      public void SetGravity()

          //Si estamos tocando el suelo
          if (player.isGrounded)
    {
          //La velocidad de caída es igual a la gravedad en valor negativo * Time.deltaTime.
          fallvelocity = -gravity * Time.deltaTime;
          moveplayer.y = fallvelocity;
    }
    playerAnimController.SetBool(IsGrounded)
    SlideDown(); //Llamamos a la función SlideDown() para comprobar si estamos en una pendiente


     */


    /*if (velocity != Vector3.zero)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), 0.2F);
    }

    transform.Translate(velocity * movementSpeed * Time.deltaTime, Space.World);
}

private void SpeedControl()
{
    Vector3 flatVel = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
    if (flatVel.magnitude > movementSpeed)
    {
        Vector3 limitedVel = flatVel.normalized * movementSpeed;
        rigidbody.velocity = new Vector3(limitedVel.x, rigidbody.velocity.y, limitedVel.z);
    }
}*/
}
