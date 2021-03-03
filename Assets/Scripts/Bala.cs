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
    private float poisonDuration;
    private float freezeDuration;
    private float areaDamage;
    private float minArea;
    private bool multiBala;
    private bool flameThrower;

    private List<GameObject> targetsArea;
    public void BalaInit(float _velocitatBala, float _damage, Transform _target, float _pushForce, float _posionDamage, float _posionDuration, float _freezeDuration, GameObject _efecteImpacte, float _areaDamage, bool _multiBala, float _minArea, bool flameThrower)
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
        areaDamage = _areaDamage;
        multiBala = _multiBala;
        minArea = _minArea;
    }
    public void Target(Transform _target) 
    {
        target = _target;
    }

    private void Start()
    {
        if(areaDamage > 0 && (poisonDamage > 0 || minArea > 0))
        {
            targetsArea = buscaEnemicsArea(areaDamage, target.position);
        } else
        {
            targetsArea = buscaEnemicsArea(areaDamage, this.transform.position);
        }
   
            
     
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

        if (areaDamage > 0)
        {
            // Aqui s'activa el danyo en area
            if (multiBala)
            {
              //SHOTGUN
              for (int i = 0; i < targetsArea.Count; i++)
                {
                   // Estem atancat a gass a les bales
                   // GameObject balaGO = (GameObject)Instantiate(this.gameObject.balaPrefab, puntBales.position, puntBales.rotation);
                   //Bala b = balaGO.GetComponent<Bala>();
                    Debug.Log("Shotgun " + i);
                }
            } else {
                if (poisonDamage > 0)
                {
                    //VENOM
                    Debug.Log("Bala venom");
                } else
                {
                    if (minArea>0)
                    {
                        //MORTAR
                        Debug.Log("Bala mortar");
                    }
                }
                //BEARTRAP && FLAMETHROWER
                // Fer efecte que toqui i dany als tagrets que hi hagi a l'area
                for (int i = 0; i < targetsArea.Count; i++)
                {
                    if (flameThrower)
                    {
                        Debug.Log("Bala flame");
                    }
                    else
                    {
                        Debug.Log("Beartrap");
                    }
                    //ControlEnemic e = targetsArea[i].GetComponent<ControlEnemic>();
                    //e.restaVida(damage);
                }
            }


            Destroy(gameObject);


        } else
        {
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
                if (pushForce > 0)
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
                if (poisonDamage > 0)
                {
                    //e.PoisonDamage(poisonDuration, poisonDamage, e);
                    e.ActivarVeneno(poisonDuration, poisonDamage, e);
                    //StartCoroutine(e.PoisonDamage(poisonDuration, poisonDamage, e));

                }

                // Bala normal
                if (damage > 0)
                {
                    e.restaVida(damage);
                }

                Destroy(particulesImpacte, 2f);
                Destroy(gameObject);
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        }   

    }


    private List<GameObject> buscaEnemicsArea(float area, Vector3 position)
    {
        List<GameObject> enemics = new List<GameObject>();
        GameObject[] aux;

        aux = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < aux.Length; i++)
        {
            float dist = Vector3.Distance(position, aux[i].transform.position);
            
            if (Mathf.Abs(dist) < area)
            {
                //Debug.Log("Enemic " + aux[i].name);
                enemics.Add(aux[i]);
            }
        }
        return enemics;
    }


    void Descongela(ControlEnemic e)
    {
        //Debug.Log("Entra aqui");
        e.freeze = false;
    }

    
}
