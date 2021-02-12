using System.Collections;
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
    private float posionDuration;
    private float freezeDuration;


    public void BalaInit(float _velocitatBala, float _damage, Transform _target, float _pushForce, float _posionDamage, float _posionDuration, float _freezeDuration)
    {
        Debug.Log("Inicialitza dades");
        velocitatBala = _velocitatBala;
        damage = _damage;
        target = _target;
        pushForce = _pushForce;
        poisonDamage = _posionDamage;
        posionDuration = _posionDuration;
        freezeDuration = _freezeDuration;
    }
    public void Target(Transform _target) 
    {
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        //Un cop la bala ha tocat l'enemic
        Debug.Log("Target " + target);
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = velocitatBala * Time.deltaTime;
        Debug.Log("Dir " + dir);

        //Evitar traspassar enemic
        if (dir.magnitude <= 0.1f)
        {

            //Tenint la referencia de la bala apliquem els efectes definits
            // SI es 0 no fa res
            // Bala normal 
            GameObject particulesImpacte = Instantiate(efecteImpacte, transform.position, transform.rotation);
            ControlEnemic e = target.GetComponent<ControlEnemic>();
            e.restaVida(damage);
            Destroy(particulesImpacte, 2f);
            Destroy(gameObject);

            //Bala freeze



        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void EnemicTocat()
    {
        Debug.Log("Has tocat l'enemic");
        GameObject particulesImpacte = Instantiate(efecteImpacte, transform.position, transform.rotation);
        ControlEnemic e = target.GetComponent<ControlEnemic>();
        e.restaVida(damage);
        Destroy(particulesImpacte, 2f);
        Destroy(gameObject);
    }

    void EnemicPush(Vector3 dir)
    {
        //GameObject particulesImpacte = Instantiate(efecteImpacte, transform.position, transform.rotation);
        ControlEnemic e = target.GetComponent<ControlEnemic>();
        e.restaVida(damage);


        dir.y = 0;
        //Hem de moure l'enemic endarrere
        //e.gameObject.transform.position = Vector3.MoveTowards(e.gameObject.transform.position, dir, 10 * Time.deltaTime);
        e.gameObject.GetComponent<Rigidbody>().AddForce(dir.normalized * 3, ForceMode.Impulse);

        //Debug.Log("Position enemic" + e.gameObject.transform.position);
        //Destroy(particulesImpacte, 2f);
        Destroy(gameObject);
    }
}
