﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform target;
    private float velocitatBala;
    private GameObject efecteImpacte;
    private float damage;

    private float pushForce;
    private float poisonDamage;
    private float poisonDuration;
    private float freezeDuration;


    public void BalaInit(float _velocitatBala, float _damage, Transform _target, float _pushForce, float _posionDamage, float _posionDuration, float _freezeDuration, GameObject _efecteImpacte)
    {
        //Debug.Log("Inicialitza dades");
        velocitatBala = _velocitatBala;
        damage = _damage;
        target = _target;
        pushForce = _pushForce;
        poisonDamage = _posionDamage;
        poisonDuration = _posionDuration;
        freezeDuration = _freezeDuration;
        efecteImpacte = _efecteImpacte;
    }
    public void Target(Transform _target) 
    {
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        //Un cop la bala ha tocat l'enemic
        //Debug.Log("Target " + target);
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = velocitatBala * Time.deltaTime;
        //Debug.Log("Dir " + dir);

        //Evitar traspassar enemic
        if (dir.magnitude <= 0.1f)
        {
            Debug.Log("Dispara crack");
            //Tenint la referencia de la bala apliquem els efectes definits
            // SI es 0 no fa res

            // Efecte impacte
            GameObject particulesImpacte = Instantiate(efecteImpacte, transform.position, transform.rotation);
            
            ControlEnemic e = target.GetComponent<ControlEnemic>();

            // Bala push
            if(pushForce > 0)
            {
                dir.y = 0;
                //Hem de moure l'enemic endarrere
                
                //Debug.Log("Direcció " + e.transform.forward);

                e.gameObject.GetComponent<Rigidbody>().AddForce(e.transform.forward * -pushForce, ForceMode.Impulse);
            }

            // Bala freeze
            if (freezeDuration > 0)
            {
                //Debug.Log("Entra a congelar");
                e.freeze = true;
                e.Descongela(freezeDuration);

            }

            // Bala venom
            if(poisonDamage > 0)
            {
                //e.PoisonDamage(poisonDuration, poisonDamage, e);
                e.ActivarVeneno(poisonDuration, poisonDamage, e);
                //StartCoroutine(e.PoisonDamage(poisonDuration, poisonDamage, e));

            }

            // Bala normal
            if(damage > 0)
            {
                e.restaVida(damage);
            }

            Destroy(particulesImpacte, 2f);
            //Destroy(gameObject);

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }




    void Descongela(ControlEnemic e)
    {
        //Debug.Log("Entra aqui");
        e.freeze = false;
    }

    
}
