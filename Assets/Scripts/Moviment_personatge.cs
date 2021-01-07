using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moviment_personatge : MonoBehaviour
{
    public CharacterController controller;
    public Camera cam;

    public float velocitat = 6f;
    public float gravetat = 20f;

    public float temps_rotacio = 0.1f;
    public float vel_rotacio;
    public float jump = 3f;
    public Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
     
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        float vel_aux = moveDirection.y;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref vel_rotacio, temps_rotacio);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;

            moveDirection *= velocitat;
            if (!controller.isGrounded)
            {
                moveDirection.x *= 0.5f;
                moveDirection.z *= 0.5f;
            }
            moveDirection.y = vel_aux;
        } else
        {
            moveDirection.x = Mathf.Lerp(moveDirection.x, 0, 0.2f);
            moveDirection.z = Mathf.Lerp(moveDirection.z, 0, 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDirection.y = jump;
        }
       
       if (!controller.isGrounded)
        {
            moveDirection.y -= gravetat * Time.deltaTime;
        }
       
        controller.Move(moveDirection*Time.deltaTime);

      }

}
