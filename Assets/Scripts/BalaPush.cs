using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPush : MonoBehaviour
{
    private Transform target;

    public float velocitatBala = 50f;

    public GameObject efecteImpacte;

    public float hurt = 0;
    public void Target(Transform _target) 
    {        
        target = _target;
        
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Target " + target);
        //Un cop la bala ha tocat l'enemic
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = velocitatBala * Time.deltaTime;

        //Evitar traspassar enemic
        if (dir.magnitude <= 0.1f)
        {
            EnemicTocat(dir);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void EnemicTocat(Vector3 dir)
    {
        //GameObject particulesImpacte = Instantiate(efecteImpacte, transform.position, transform.rotation);
        ControlEnemic e = target.GetComponent<ControlEnemic>();
        e.restaVida(hurt);


        dir.y = 0;
        //Hem de moure l'enemic endarrere
        //e.gameObject.transform.position = Vector3.MoveTowards(e.gameObject.transform.position, dir, 10 * Time.deltaTime);
        e.gameObject.GetComponent<Rigidbody>().AddForce(dir.normalized * 3, ForceMode.Impulse);

        Debug.Log("Position enemic" + e.gameObject.transform.position);
        //Destroy(particulesImpacte, 2f);
        Destroy(gameObject);
    }
}
