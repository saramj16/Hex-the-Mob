using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePoints : MonoBehaviour
{
    public static Transform[] points;
    // Start is called before the first frame update
    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    /**
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            for (int i = 0; i < points.Length; i++)
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
                Instantiate(resource, points[i].position, points[i].rotation);
            }
            countdown = timeToSpawn;
        }
        countdown -= Time.deltaTime;
    }
    **/
}