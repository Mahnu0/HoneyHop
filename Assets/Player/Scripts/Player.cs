using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float JumpForce;
    [SerializeField] float rotationSpeed;

    Rigidbody rb;
    Collision col;

    public Respawneador respawneador;

    bool isGrounded = true;
    bool jumping = false;
    bool orbitalArrow = false;

    static public int attemps;

    Vector3 initialPosition;
    float initialSpeed;
    float initialJumpForce;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collision>();

        respawneador = GetComponent<Respawneador>();

        initialPosition = transform.position;
        initialSpeed = Speed;
        initialJumpForce = JumpForce;
    }


    void Update()
    {
        if(orbitalArrow == false)
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                jumping = true;
                isGrounded = false;
            }            
        }
        else if (orbitalArrow == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Rotate(0, 0, rotationSpeed);
            }
            else
            {
                Speed = initialSpeed;
            }
        }


        // ONLY FOR TESTING, REMEMBER TO DELETE IN FINAL VERSION
        if (Input.GetKeyDown(KeyCode.R))
        {
            respawneador.Respawn(0);
        }

    }

    void FixedUpdate()
    {
        if (orbitalArrow == false)
        {
            if (jumping)
            {
                rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
                jumping = false;
            }

            rb.velocity = new Vector3(Speed, rb.velocity.y, 0);
        }
        else
        {
            Vector3 pointingDirection = new Vector3(transform.right.x, transform.right.y, 0);

            rb.velocity = pointingDirection * Speed;
        }
        

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Killer") || other.gameObject.CompareTag("Enemy"))
        {
            respawneador.Respawn(2);
        }
        else if(other.gameObject.CompareTag("Portal") && orbitalArrow == false)
        {
            orbitalArrow = true;

            Physics.gravity = Vector3.zero;

            rb.velocity = new Vector3(Speed, 0, 0);
        }
    }

    
}
