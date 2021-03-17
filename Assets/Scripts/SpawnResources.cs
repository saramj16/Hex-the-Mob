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

    public Transform bruixa;

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

                float dist = Vector3.Distance(resourcePosition, bruixa.transform.position);

                if(Mathf.Abs(dist) < 4f)
                {
                    //Debug.Log("Posa recurs: " + resource[element].prefab.name);
                    Instantiate(resource[element].prefab, resourcePosition, Quaternion.identity);
                    countdown = timeToSpawn;
                } else
                {
                    countdown = 0;
                }
            }
            
        }
        countdown -= Time.deltaTime;
    }

    Vector3 calculateResourcePosition()
    {
        int num = Random.Range(1, ground.childCount);
        float x_coord = ground.GetChild(num).position.x;
        float y_coord = positionYMesh(ground.GetChild(num).gameObject);
        float z_coord = ground.GetChild(num).position.z;
        Vector3 pos = new Vector3(x_coord,y_coord+0.1f,z_coord);
        return pos;
    }

    public float positionYMesh(GameObject g)
    {
        float altura = 0;

        LayerMask mask = LayerMask.GetMask("Terra");

        RaycastHit hit;
        Vector3 aux = g.transform.position;
        aux.y = 300f;
        if (Physics.Raycast(aux, -g.transform.forward * 1000f, out hit, Mathf.Infinity, mask))
        {
            //Debug.DrawRay(aux, -g.transform.forward * 1000f, Color.blue, 10f);

            altura = hit.point.y;
            // Debug.Log("Altura: " + altura);
        }

        return altura;
    }
}
