﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moviment_personatge : MonoBehaviour
{
    public CharacterController controller;
    public Camera cam;

    public float velocitat_base = 0.4f;
    public float velocitat_running = 1f;
    public float velocitat = 0.4f;
    public float gravetat = 20f;

    public float temps_rotacio = 0.1f;
    public float vel_rotacio;
    public float jump = 4f;
    public Vector3 moveDirection = Vector3.zero;
    public Animator anim;

    public bool inWater;
    public bool inPedra;
    public bool inPont;
    public AudioSource waterStep;
    public AudioSource grassStep;

    public GameObject infoPont;
    public GameObject infoTorre;

    private void Start()
    {
   
        controller = GetComponent<CharacterController>();
   
    }

    // Update is called once per frame
    void Update()
    {
        
        if(cam.enabled == true)
        {
            //Activar a veure si esta tocant pont o pedra
            touchingCollider();

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            anim.SetFloat("VelX", horizontal);
            anim.SetFloat("VelY", vertical);

            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            float vel_aux = moveDirection.y;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref vel_rotacio, temps_rotacio);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                moveDirection = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;

                moveDirection *= velocitat;
             /*   if (!controller.isGrounded)
                {
                    moveDirection.x *= 0.5f;
                    moveDirection.z *= 0.5f;
                }*/
                moveDirection.y = vel_aux;
            }
            else
            {
                moveDirection.x = Mathf.Lerp(moveDirection.x, 0, 0.2f);
                moveDirection.z = Mathf.Lerp(moveDirection.z, 0, 0.2f);
            }

            if (anim.GetBool("isRunning"))
            {
                JumpingRunAnimations();
            }
            else
            {
                JumpingAnimations();
            }

            RunAnimations();

            controller.Move(moveDirection * Time.deltaTime);
        }
       
      }

    void JumpingRunAnimations()
    {
        // Si apreten l'espai per saltar
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            // Esta saltant
            //Debug.Log("Esta saltant");
            anim.SetBool("jumping", true);
            moveDirection.y = jump;


        }
        if (anim.GetBool("onAir") && controller.isGrounded)
        {
            //Debug.Log("Terra");
            anim.SetBool("onAir", false);
        }

        if (!controller.isGrounded)
        {
            //Debug.Log("Esta baixant");
            anim.SetBool("jumping", false);
            anim.SetBool("onAir", true);
            moveDirection.y -= gravetat * Time.deltaTime;
        }
    }
    void JumpingAnimations()
    {

        // Si apreten l'espai per saltar
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            // Esta saltant
            //Debug.Log("Esta saltant");
            anim.SetBool("jumping", true);
            moveDirection.y = jump;

            
        }

        if (anim.GetBool("onAir") && controller.isGrounded)
        {
            //Debug.Log("Terra");
            anim.SetBool("onAir", false);
            stepSound();
        }

        if (!controller.isGrounded)
        {
            //Debug.Log("Esta baixant");
            anim.SetBool("jumping", false);
            anim.SetBool("onAir", true);
            moveDirection.y -= gravetat * Time.deltaTime;
        }
    }

    
    void RunAnimations()
    {
        // Control animacions correr
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("Running");
            velocitat = velocitat_running;
            anim.SetBool("isRunning", true);
        }
        // Control animacions caminar
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Debug.Log("ja no està running");
            velocitat = velocitat_base;
            
            anim.SetBool("isRunning", false);
        }
        anim.SetFloat("velocitat", velocitat);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water") {
            inWater = true;
        }

        if (other.tag == "Pedra")
        {
            inPedra = true;
        }

        if (other.tag == "Pont")
        {
            inPont = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            inWater = false;
        }

        if (other.tag == "Pedra")
        {
            inPedra = false;
        }

        if (other.tag == "Pont")
        {
            inPont = false;
        }
    }

    public void touchingCollider()
    {
        if(inPont == true)
        {
            infoPont.SetActive(true);
            
        } else
        {
            infoPont.SetActive(false);
        }
        if(inPedra == true)
        {
            infoTorre.SetActive(true);
        } else
        {
            infoTorre.SetActive(false);
        }
    }

    public void stepSound() {
        AudioSource step;
        if (inWater)
        {
            step = waterStep;
        }
        else {
            step = grassStep;
        }

        step.pitch = Random.Range(0.8f,1.3f);
        step.Play();
    }
}
