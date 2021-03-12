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
        transform.Translate(targetDir * Time.deltaTime*5);
    }

    public void setTargetDirection(Vector3 direction)
    {
        targetDir =  direction.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Treure vida a l'enemic
            Debug.Log("Collisiona amb l'enemic");
            other.gameObject.GetComponent<ControlEnemic>().restaVida(dany);

        }
    }
}