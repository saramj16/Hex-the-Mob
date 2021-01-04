using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemic : MonoBehaviour
{
    public float velocitat = 0.1f;

    private Transform target;
    private int waypointIndex = 0;

    public float vida = 100f;

    public GameObject torre;
    // Start is called before the first frame update
    void Start()
    {
        torre = GameObject.Find("Hexentrum");
        target = Waypoints.points[0];

        //Debug.Log("Target " + target);
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
            Debug.Log("Ataquem a la torre");

            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void restaVida(float dany)
    {

        Debug.Log("Vida" + vida);
        vida -= dany;
        if (vida <= 0)
        {
            Debug.Log("Has mort" + vida);
            Destroy(gameObject);
        }
    }


}
