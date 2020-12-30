using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform target;

    public float velocitatBala = 70f;

    public GameObject efecteImpacte;

    public float hurt = 50;
    public void Target(Transform _target) 
    {
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
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
            EnemicTocat();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void EnemicTocat()
    {
        GameObject particulesImpacte = Instantiate(efecteImpacte, transform.position, transform.rotation);
        ControlEnemic e = target.GetComponent<ControlEnemic>();
        e.restaVida(hurt);
        Destroy(particulesImpacte, 2f);
        Destroy(gameObject);
    }
}
