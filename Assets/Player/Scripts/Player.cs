using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float SpeedX;
    [SerializeField] float JumpForce;

    Rigidbody rb;
    Collision col;

    public Respawneador respawneador;

    bool isGrounded = true;
    bool jumping = false;

    static public int attemps;

    Vector3 initialPosition;
    float initialSpeed;
    float initialJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collision>();

        respawneador = GetComponent<Respawneador>();

        initialPosition = transform.position;
        initialSpeed = SpeedX;
        initialJumpForce = JumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            jumping = true;
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            respawneador.Respawn(0);
        }
    }

    void FixedUpdate()
    {
        if(jumping)
        {
            rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
            jumping = false;
        }

        rb.velocity = new Vector3(SpeedX, rb.velocity.y, 0);
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
        if (other.gameObject.CompareTag("Killer"))
        {
            respawneador.Respawn(2);
        }
    }

    
}
