using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoureCamera : MonoBehaviour
{

    private Rigidbody rb;
    public float velocidad = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
        Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);

        //Aplico ese movimiento al RigidBody del jugador
        rb.AddForce(movimiento);

    }
}
