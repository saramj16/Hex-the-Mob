using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBales : MonoBehaviour
{
    public GameObject bala;

    GameObject pareBales;

    List<Collider> enemyList;

    float timeSinceLastShot = 0f;
    float timeBetweenShots = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
        enemyList = new List<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (enemyList.Count > 0)
        {
            transform.LookAt(enemyList[0].gameObject.transform.position);


            if (timeSinceLastShot >= timeBetweenShots)
            {
                timeSinceLastShot %= timeBetweenShots; //és com fer un = 0 però no perds el petit temps que passa del timeBetweenShots.
                Disparar();
            }
        }



    }

    private void Awake()
    {
        pareBales = GameObject.Find("Bullets");
    }

    void Disparar()
    {

        if (enemyList.Count > 0)
        {
            GameObject balaTemporal = Instantiate(bala, transform.position, Quaternion.identity);
            balaTemporal.transform.parent = pareBales.transform;
            balaTemporal.GetComponent<Bullet>().direction = transform.forward;
            balaTemporal.GetComponent<Bullet>().gb = this;
        }

    }

    public void enemykilled(Enemy enemy)
    {
        enemyList.Remove(enemy.GetComponent<Collider>());

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HERE WE ARE");

        if (other.gameObject.tag == "Enemy")
        {
            enemyList.Add(other);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyList.Remove(other);
        }

    }
}