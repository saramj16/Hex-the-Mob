using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemic : MonoBehaviour
{
    public float velocitat = 0.1f;

    private Transform target;
    private int waypointIndex = 0;

    public float vida = 100f;
    public float atac = 10f;

    public bool freeze;

    public GameObject torre;
    public List<Enemic> enemic = new List<Enemic>();
    public string nomAux;

    private bool final;
    private bool ataquem;

    // Start is called before the first frame update
    void Start()
    {
        final = false;
        ataquem = false;
        freeze = false;
        target = Waypoints.points[0];
        nomAux = this.gameObject.name;
        for (int i = 0; i < enemic.Count; i++)
        {
            nomAux = nomAux.Replace("(Clone)", string.Empty);
            //Debug.Log("Nom1 " + name + " Nom2 " + enemic[i].prefab.name);
            if (enemic[i].prefab.name == nomAux)
            {
                //Debug.Log("Mira que funcioni");
                vida = enemic[i].vida;
                atac = enemic[i].atac;
                velocitat = enemic[i].velocitat;
            }
        }

        //Debug.Log("Torre"+ GameObject.Find("Hexentrum"));
       
    }

    // Update is called once per frame
    void Update()
    {
        if(freeze == false)
        {
            if(ataquem == true)
            {
                AtacaTorre();
            } else
            {
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * velocitat * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, target.position) <= 0.4f)
                {
                    GetNextWaypoint();
                }
            }

        }

        

    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
              
            if(final == false)
            {
                VesAlWayPointAtac();
                final = true;
            }
       
            //Destroy(gameObject);
            //Hem d'atacar a la torre

            //Ho hem de cirdar cada 5 segons
            // Buscar el seu nou waypoint


            //Invoke("AtacaTorre", 3.0f);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

  /*  public void PoisonDamage(float poisonDuration, float poisonDamage, ControlEnemic e)
    {
        float duration = poisonDuration;
        if (duration > 0)
        {
            duration--;
            Debug.Log("Duration " + duration);
            e.restaVida(poisonDamage);
            Invoke("PoisonDamage(" + duration + "," + poisonDamage + "," + e + ")", 1f);
            //Debug.Log("Segueix la Corutina de merda");

        } else
        {
            Debug.Log("Ja estas makuina");
        }
    }*/

    void ActivarAtacEnemic()
    {
        ataquem = true;
    }

    void VesAlWayPointAtac()
    {

        Debug.Log("Va al WayPoint");
        GameObject[] waypointAtac = GameObject.FindGameObjectsWithTag("WayPointAtac");

        int random = Random.Range(0, waypointAtac.Length);

        target = waypointAtac[random].transform;

        Invoke("ActivarAtacEnemic", 2f);
    }
    public void ActivarVeneno(float poisonDuration, float poisonDamage, ControlEnemic e)
    {
        //Debug.Log("Activem corrutina");
        StartCoroutine(PoisonDamage(poisonDuration, poisonDamage, e));
    }

    public IEnumerator PoisonDamage(float poisonDuration, float poisonDamage, ControlEnemic e)
    {

        float duration = 0;

        while (duration < poisonDuration)
        {
            Debug.Log("Poison");
            e.restaVida(poisonDamage);
            duration++;
            yield return new WaitForSeconds(1f);
        }
        
    }

    public void Descongela(float freezeDuration)
    {
        //Debug.Log("Entra");
        Invoke("IsNotFreeze", freezeDuration);
    }

    void IsNotFreeze()
    {
        //Debug.Log("Descongela al parguelas ese");
        freeze = false;
    }

    void AtacaTorre()
    {
        torre = GameObject.Find("Hexentrum");
        if(torre != null)
        {
            torre.gameObject.GetComponent<Hexentrum>().restaVida(atac);
            //Invoke("AtacaTorre", 3.0f);
        }
    }

    public void restaVida(float dany)
    {

        //Debug.Log("Vida" + vida);
        vida -= dany;
        if (vida <= 0)
        {
            Debug.Log("Enemic mort" + vida);
            Destroy(gameObject);
        }
    }


}
