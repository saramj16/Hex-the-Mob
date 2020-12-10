using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemic : MonoBehaviour
{
    public float velocitat = 4f;

    private Transform target;
    private int waypointIndex = 0;

    public float vida = 100f;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void restaVida(float dany)
    {

        vida -= dany;
        if (vida <= 0)
        {

            Destroy(gameObject);
        }
    }


}
