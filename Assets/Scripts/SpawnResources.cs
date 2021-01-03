using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    public Transform ground;
    public float countdown;
    public float timeToSpawn;
    public int element;
    public List<Resource> resource;
    public int numSpawners;
    Vector3 resourcePosition;
    // Start is called before the first frame update
    void Start()
    {
        numSpawners = 2;
        timeToSpawn = 5f;
        countdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            for (int i = 0; i < numSpawners; i++)
            {
                resourcePosition = calculateResourcePosition();
                element = Random.Range(1, 4);
                switch (element)
                {
                    case 1:
                        //Aire
                        element = 1;
                        break;
                    case 2:
                        //Terra
                        element = 2;
                        break;
                    case 3:
                        //Foc
                        element = 3;
                        break;
                    case 4:
                        //Aigua
                        element = 4;
                        break;
                }
                Instantiate(resource[element].prefab, resourcePosition, Quaternion.identity);
            }
            countdown = timeToSpawn;
        }
        countdown -= Time.deltaTime;
    }

    Vector3 calculateResourcePosition()
    {
        int num = Random.Range(1, ground.childCount);
        float x_coord = ground.GetChild(num).position.x;
        float y_coord = ground.GetChild(num).position.y;
        float z_coord = ground.GetChild(num).position.z;
        Vector3 pos = new Vector3(x_coord,y_coord+0.3f,z_coord);
        return pos;
    }
}
