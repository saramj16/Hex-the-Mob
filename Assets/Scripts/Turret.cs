using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    public string nomTorre;

    [Header("Paràmetres")]
    public float range;
    public float fireRate;
    private float fireCountdown = 1f;
    public float velRotacio;
    public float areaDamage;
    public Bales bala;

    [Header("Configuració")]

    public string tag_enemic = "Enemy";

    public Transform pivotArma;
    public Transform puntBales;



    // Start is called before the first frame update
    void Start()
    {
        //Cridar a la funció 2 cops cada segon
        InvokeRepeating("BuscaEnemics", 0f, 0.5f);
    }

    void BuscaEnemics()
    {
        //Buscar si hi ha enemics a l'escena
        GameObject[] enemics = GameObject.FindGameObjectsWithTag("Enemy");
        float distanciaCurta = Mathf.Infinity;
        GameObject enemicProper = null;
        //Calcular la distància de l'enemic més proper
        foreach(GameObject enemic in enemics)
        {
            float distanciaEnemic = Vector3.Distance(transform.position, enemic.transform.position);
            if (distanciaEnemic < distanciaCurta)
            {
                distanciaCurta = distanciaEnemic;
                enemicProper = enemic;
            }
        }

        //Seleccionar com a objectiu l'enemic més proper
        if (enemicProper != null && distanciaCurta <= range)
        {
            target = enemicProper.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion apuntarArma = Quaternion.LookRotation(dir);
        Vector3 rotacio = Quaternion.Lerp(pivotArma.rotation, apuntarArma, Time.deltaTime * velRotacio).eulerAngles;
        //Rotar en l'eix Y
        pivotArma.rotation = Quaternion.Euler(0f, rotacio.y, 0f);
        //pivotArma.LookAt(new Vector3(target.position.x, pivotArma.position.y, target.position.z));

        if(fireCountdown <= 0)
        {
            //Debug.Log("Dispara");
            Dispara();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Dispara()
    {

        //Debug.Log("Dispara");
        GameObject balaGO = (GameObject) Instantiate(bala.balaPrefab, puntBales.position, puntBales.rotation);
        Bala b = balaGO.GetComponent<Bala>();

        if (b != null)
        {
             b.BalaInit(bala.velocitatBala, bala.damage, target, bala.pushForce, bala.poisonDamage, bala.posionDuration, bala.freezeDuration, bala.efecteImpacte, areaDamage);
        }

    }
    
    //Executa quan es selecciona la 'torreta'
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, areaDamage);
    }


    public void UpgradeTorre()
    {
        // Aqui canviem el que sigui
        range += 0.2f;

    }
}
