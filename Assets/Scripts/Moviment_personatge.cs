using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moviment_personatge : MonoBehaviour
{
    public Rigidbody controller;

    public Camera cam;

    public float velocitat = 6f;
    public float temps_rotacio = 0.1f;
    public float vel_rotacio;
    public float salt = 4f;

    private void Start()
    {
       
        controller = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputForward = Input.GetAxisRaw("Vertical");
        float inputRight = Input.GetAxisRaw("Horizontal");
        Vector3 inputDirection = new Vector3(inputRight, 0f, inputForward).normalized;

        //Agafar forward i right de la cam, treure la Y i normalitzar.
        Vector3 cameraForward = cam.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        Vector3 cameraRight = cam.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();
        //per la rotacio del pj
        //agafar la velocitat del rb

        float y = controller.velocity.y;

        if(inputDirection.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref vel_rotacio, temps_rotacio);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = inputForward * cameraForward + inputRight * cameraRight + Vector3.up * y;
            controller.velocity = moveDir * velocitat;
            //controller.Move(moveDir.normalized * velocitat * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            controller.AddForce(new Vector3(0, salt, 0), ForceMode.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //controller.velocity *= velocitat;
        }

    }


}
