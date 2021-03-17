using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBruixa : MonoBehaviour
{
    Vector3 targetDir;
    float flyTime = 3f;

    float dany = 500f;
    // Start is caled before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", flyTime);

    }


    void DestroyBullet()
    {

        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, targetDir, Color.red, 3f);
        //transform.Translate(targetDir * Time.deltaTime * 5f, Space.World);
        transform.transform.position += (targetDir * Time.deltaTime * 5f);
    }

    public void setTargetDirection(Vector3 direction)
    {
        targetDir =  direction.normalized;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("COLLISION");
        if (other.gameObject.tag == "Enemy")
        {
            //Treure vida a l'enemic
            Debug.Log("Enemic tocat!");
            other.gameObject.GetComponent<ControlEnemic>().restaVida(dany);

        }
    }
}