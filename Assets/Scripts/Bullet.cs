using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    [HideInInspector]
    public Vector3 direction;
    public GeneradorBales gb;

    float flyTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", flyTime);
        rb.AddRelativeForce(direction * 30, ForceMode.Impulse);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);

    }

    void DestroyBullet()
    {

        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            DestroyBullet();
        }
    }
}