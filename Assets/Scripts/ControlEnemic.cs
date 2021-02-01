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

    public GameObject torre;
    public List<Enemic> enemic = new List<Enemic>();
    public string name;

    // Start is called before the first frame update
    void Start()
    {
       
        target = Waypoints.points[0];
        name = this.gameObject.name;
        for (int i = 0; i < enemic.Count; i++)
        {
            name = name.Replace("(Clone)", string.Empty);
            //Debug.Log("Nom1 " + name + " Nom2 " + enemic[i].prefab.name);
            if (enemic[i].prefab.name == name)
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
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * velocitat * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            //Destroy(gameObject);
            //Hem d'atacar a la torre
            //Debug.Log("Ataquem a la torre");
            //Ho hem de cirdar cada 5 segons
            AtacaTorre();
            //Invoke("AtacaTorre", 3.0f);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
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
            Debug.Log("Has mort" + vida);
            Destroy(gameObject);
        }
    }


}
