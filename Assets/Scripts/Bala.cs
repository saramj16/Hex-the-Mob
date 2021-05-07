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
    private bool minArea;
    private bool multiBala;
    private bool flameThrower;
    private bool isGolem;
    private bool isSniper;
    private GameObject prefab;
    private GameObject torre;
    private List<GameObject> targetsArea;
    public GameObject bullet;
    public void BalaInit(float _velocitatBala, float _damage, Transform _target, float _pushForce, float _posionDamage, float _posionDuration, float _freezeDuration, GameObject _efecteImpacte, float _areaDamage, bool _multiBala, bool _minArea, bool _flameThrower, bool _isGolem, bool _isSniper, GameObject _prefab, GameObject _torre)
    {
        Debug.Log("Inicialitza dades");
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
        flameThrower = _flameThrower;
        isGolem = _isGolem;
        isSniper = _isSniper;
        prefab = _prefab;
        torre = _torre;
    }
    public void Target(Transform _target) 
    {
        target = _target;
    }

    void Start()
    {
        //Debug.Log("Entra a l'Start");
        if (areaDamage > 0 && (poisonDamage > 0 || minArea))
        {
            targetsArea = buscaEnemicsArea(areaDamage, target.position);
        }
        else
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
                   GameObject balaGO = (GameObject)Instantiate(prefab, this.transform.position, this.transform.rotation);
                   Bala b = balaGO.GetComponent<Bala>();
                    if (b != null)
                    {
                        //Debug.Log("Shotgun " + i);
                        b.BalaInit(velocitatBala, damage, targetsArea[i].transform, pushForce, poisonDamage, 0, freezeDuration, efecteImpacte, 0, false, minArea, flameThrower, isGolem, isSniper, prefab, torre);
                    }
                    
                }
            } else {
                if (targetsArea.Count==0)
                {
                    Destroy(gameObject);
                    return;
                }
                Vector3 dir = targetsArea[0].transform.position - transform.position;
                float distanceThisFrame = velocitatBala * Time.deltaTime;
                //Debug.Log("Dir " + dir);

                //Evitar traspassar enemic
                if (dir.magnitude <= 0.1f)
                {
                    if (poisonDamage > 0)
                    {
                        //VENOM
                        for (int i = 0; i < targetsArea.Count; i++)
                        {
                            Debug.Log("Bala venom: " + (i + 1));
                            //Aplicar efecte VENOM
                            ControlEnemic e = targetsArea[i].GetComponent<ControlEnemic>();
                            e.ActivarVeneno(poisonDuration, poisonDamage, e);
                        }

                    }
                    else
                    {
                        if (minArea)
                        {
                            for (int i = 0; i < targetsArea.Count; i++)
                            {
                                //MORTAR
                                Debug.Log("Bala mortar");
                                ControlEnemic e = targetsArea[i].GetComponent<ControlEnemic>();
                                e.restaVida(damage);
                            }
                        }
                        else
                        {
                            //BEARTRAP && FLAMETHROWER
                            // Fer efecte que toqui i dany als tagrets que hi hagi a l'area

                            if (flameThrower)
                            {
                                Debug.Log("Bala flame");
                                torre.GetComponent<Turret>().activaEfecte();
                            }
                            else
                            {
                                torre.GetComponent<BearTrapTrigger>().ActivaTorre();

                            }
                            for (int i = 0; i < targetsArea.Count; i++)
                            {
                                ControlEnemic e = targetsArea[i].GetComponent<ControlEnemic>();
                                e.restaVida(damage);
                            }
                        }

                    }
                    Destroy(gameObject);
                }

                //Debug.Log("Mou bala");
                transform.Translate(dir.normalized * distanceThisFrame, Space.World);

            }
                    


        } else
        {
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
                
                //Tenint la referencia de la bala apliquem els efectes definits
                // SI es 0 no fa res

                // Efecte impacte
                GameObject particulesImpacte = null;
                if (efecteImpacte != null)
                {
                    particulesImpacte = Instantiate(efecteImpacte, transform.position, transform.rotation);
                }

                ControlEnemic e = target.GetComponent<ControlEnemic>();

                // Bala push
                if (pushForce > 0)
                {
                    dir.y = 0;
                    //Hem de moure l'enemic endarrere

                    //Debug.Log("Direcció " + e.transform.forward);
                    torre.GetComponent<Turret>().activaEfecte();
                    e.gameObject.GetComponent<Rigidbody>().AddForce(e.transform.forward * -pushForce, ForceMode.Impulse);
                }

                // Bala freeze
                if (freezeDuration > 0)
                {
                    //Debug.Log("Entra a congelar");
                    e.freeze = true;
                    e.Descongela(freezeDuration);

                }

                if (isGolem)
                {
                    //Debug.Log("El golem ataca crack");
                    torre.transform.GetChild(0).GetComponent<GolemTrigger>().ActivaAnimacio();
                    //torre.GetCh.GetComponent<BearTrapTrigger>().ActivaTorre();
                }

                if (isSniper)
                {
                    //Debug.Log("Sniper");
                    bullet = (GameObject)Instantiate(Resources.Load("BalaBruixa"), transform.position, transform.rotation);
                    bullet.GetComponent<BalaBruixa>().setTargetDirection(dir);
                }

                if (damage == 999)
                {
                    Debug.Log("VORTEX");
                    torre.GetComponent<VortexAnim>().ActivaAnimacio();
                }

                // Bala venom
               /* if (poisonDamage > 0)
                {
                    //e.PoisonDamage(poisonDuration, poisonDamage, e);
                    e.ActivarVeneno(poisonDuration, poisonDamage, e);
                    //StartCoroutine(e.PoisonDamage(poisonDuration, poisonDamage, e));

                }*/

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
