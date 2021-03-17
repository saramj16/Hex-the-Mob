using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    Transform ground;
    public Transform fire;
    public Transform water;
    public Transform earth;
    public Transform air;

    bool isFireActive;
    bool isEarthActive;
    bool isWaterActive;
    bool isAirActive;
    public float countdown;
    public float timeToSpawn;
    public int element;
    public List<Resource> resource;
    public int numSpawners;
    Vector3 resourcePosition;

    GameObject GameMaster;
    WaveManager waveManager;
    // Start is called before the first frame update
    void Start()    
    {
        GameMaster = GameObject.Find("GameMaster");
        numSpawners = 2;
        timeToSpawn = 5f;
        countdown = timeToSpawn;
        waveManager = GameMaster.GetComponent<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0 && waveManager.esDia)
        {
            for (int i = 0; i < numSpawners; i++)
            {
                //Debug.Log("NOU RECURS");
                
                element = Random.Range(1, 4);
                switch (element)
                {
                    case 1:
                        //Terra
                        ground = earth;
                        element = 1;
                        break;
                    case 2:
                        //Aire
                        ground = fire;
                        element = 2;
                        break;
                    case 3:
                        //Aigu
                        ground = water;
                        element = 3;
                        break;
                    case 4:
                        //Foc
                        ground = air;
                        element = 4;
                        break;
                }
                // Calculem si la zona del recurs ja esta activa i li diem la posicio

                resourcePosition = calculateResourcePosition();
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
        Vector3 pos = new Vector3(x_coord,y_coord+0.1f,z_coord);
        return pos;
    }
}
