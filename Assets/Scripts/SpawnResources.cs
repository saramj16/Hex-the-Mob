using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    public GameObject air;
    public GameObject fire;
    public GameObject water;
    public GameObject earth;
    public float countdown;
    public float timeToSpawn;
    public int element;
    public GameObject resource;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<ResourcePoints.points.Length; i++)
        {
            Debug.Log("Punt"+ i);
        }
        timeToSpawn = 5f;
        //air = GameObject.Find("Air");
        //fire = GameObject.Find("Fire");
        //water = GameObject.Find("Water");
        //earth = GameObject.Find("Earth");
        countdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            for (int i = 0; i < ResourcePoints.points.Length; i++)
            {
                element = Random.Range(1, 4);
                switch (element)
                {
                    case 1:
                        resource = air;
                        break;
                    case 2:
                        resource = fire;
                        break;
                    case 3:
                        resource = water;
                        break;
                    case 4:
                        resource = earth;
                        break;
                }
                Instantiate(resource, ResourcePoints.points[i].position, ResourcePoints.points[i].rotation);
            }
            countdown = timeToSpawn;
        }
        countdown -= Time.deltaTime;
    }
}
