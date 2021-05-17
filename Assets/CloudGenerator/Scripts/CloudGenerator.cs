using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    public GameObject[] cloud_model;
    private int cloudModels;
    public Vector3 cloudPosRng;

    public float secondsBetwnClouds;
    private float timeToCloud;

    // Start is called before the first frame update
    void Start()
    {
        cloudModels = cloud_model.Length;

        createStartingClouds();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToCloud >= secondsBetwnClouds) //Anem contant, i cada secBtwnClds segons, fem un nuvol nou
        {
            createCloud();
            timeToCloud = 0;
        }
        else {
            timeToCloud += Time.deltaTime;
        }
        
    }

    void createCloud() {
        int cloudType = Mathf.FloorToInt(Random.Range(0,cloudModels-0.001f));
        Vector3 cloud_position = new Vector3(Random.Range(-cloudPosRng.x,cloudPosRng.x) + this.transform.position.x, 
                                        Random.Range(-cloudPosRng.y, cloudPosRng.y) + this.transform.position.y, 
                                        Random.Range(-cloudPosRng.z, cloudPosRng.z) + this.transform.position.z);
        Quaternion cloud_orientation;
        if (Random.value > 0.5) //Els invertim per tenir una mica mes de varietat
        {
            cloud_orientation = Quaternion.Euler(-90, 90, 0);
        }
        else {
            cloud_orientation = Quaternion.Euler(-90, 90, 180);
        }
        
        Instantiate(cloud_model[cloudType],cloud_position,cloud_orientation,this.transform);
        
    }

    void createStartingClouds() //Creem nuvols inicials perque el mapa no comenci buit
    {
        for (int i = 0; i < 8; i++)
        {
            int cloudType = Mathf.FloorToInt(Random.Range(0, cloudModels - 0.001f));
            Vector3 cloud_position = new Vector3(Random.Range(-cloudPosRng.x, cloudPosRng.x) + this.transform.position.x + i*30,
                                            Random.Range(-cloudPosRng.y, cloudPosRng.y) + this.transform.position.y,
                                            Random.Range(-cloudPosRng.z, cloudPosRng.z) + this.transform.position.z);
            Quaternion cloud_orientation;
            if (Random.value > 0.5)
            {
                cloud_orientation = Quaternion.Euler(-90, 90, 0);
            }
            else
            {
                cloud_orientation = Quaternion.Euler(-90, 90, 180);
            }

            Instantiate(cloud_model[cloudType], cloud_position, cloud_orientation, this.transform);
        }

        

    }

}
