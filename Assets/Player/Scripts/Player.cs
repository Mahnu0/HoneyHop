using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float JumpForce;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject arrow;
    [SerializeField] Image powerMeter;

    Rigidbody rb;
    Collision col;

    public Respawneador respawneador;

    bool isGrounded = true;
    bool jumping = false;
    bool orbitalArrow = false;
    bool standStill = false;
    bool refillPowerMeter = false;

    static public float standStillTime = 5;
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
        // DETECT IN WHAT MODE IS THE PLAYER
        if(!orbitalArrow)
        {
            // JUMP ON INPUT
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                jumping = true;
                isGrounded = false;
            }            
        }
        else if (orbitalArrow)
        {
            // PLAYER STANDS STILL WHILE ROTATING BETWEEN 75 AND -75 DEGREES ON INPUT
            // IF THE POWER METER IS NOT REFILLING
            if (Input.GetKey(KeyCode.Space) && refillPowerMeter == false)
            {
                float rotation = transform.rotation.eulerAngles.z;
                
                if (rotation > 180) { rotation -= 360; }

                if (rotation > 75)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 75);

                    rotationSpeed = -rotationSpeed;
                }
                
                if (rotation < -75)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -75);

                    rotationSpeed = -rotationSpeed;
                }

                transform.Rotate(0, 0, rotationSpeed);

                rb.velocity = Vector3.zero;

                standStill = true;

                // STARTS A 5s TIMER
                standStillTime -= Time.deltaTime;

                if(standStillTime <= 0)
                {
                    standStillTime = 0;
                    refillPowerMeter = true;
                }
            }
            else
            {
                standStill = false;
                
                if(standStillTime != 5 && refillPowerMeter == false)
                {
                    refillPowerMeter = true;
                }
            }

            // REFILLS THE POWER METER IF EMPTY
            

            
            
        }

        if (refillPowerMeter == true)
        {
            standStillTime += Time.deltaTime * 2f;

            if (standStillTime >= 5)
            {
                standStillTime = 5;
                refillPowerMeter = false;
            }
        }


        // !!!!!!!!!!!!! ONLY FOR TESTING, REMEMBER TO DELETE IN FINAL VERSION !!!!!!!!!!!!!!!!!!
        if (Input.GetKeyDown(KeyCode.R))
        {
            respawneador.Respawn(0);
            orbitalArrow = false;
            arrow.SetActive(false);
        }

        powerMeter.fillAmount = standStillTime / 5;

    }

    void FixedUpdate()
    {
        // DETECT IN WHAT MODE IS THE PLAYER
        if (!orbitalArrow)
        {
            // ADD FORCE FOR JUMP
            if (jumping)
            {
                rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
                jumping = false;
            }

            // MOVE THE PLAYER
            rb.velocity = new Vector3(Speed, rb.velocity.y, 0);
        }
        else if(standStill == false && orbitalArrow)
        {
            // ORBITAL ARROW MOVEMENT
            // Vector3 direction = new Vector3(transform.forward.z, transform.forward.z, 0).normalized;
            Vector3 direction = transform.right;

            rb.velocity = direction * Speed;
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
            orbitalArrow = false;
            arrow.SetActive(false);
        }
        else if(other.gameObject.CompareTag("Portal") && orbitalArrow == false)
        {
            orbitalArrow = true;

            Physics.gravity = Vector3.zero;

            arrow.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Portal") && orbitalArrow == true)
        {
            orbitalArrow = false;

            Physics.gravity = new Vector3(0, -45, 0);

            transform.rotation = quaternion.Euler(0, 0, 0);

            arrow.SetActive(false);
        }
    }    
}
