using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestioTorretes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 buscarTorreta(Vector3 puntCollision)
    {
        Debug.Log("Entra aqui");
        /*GameObject[] terreny;
        terreny = GameObject.FindGameObjectsWithTag("Terreny");

        for (int i = 0; i < terreny.Length; i++)
        {
            if (Vector3.Distance(puntCollision, terreny[i].transform.position) < 5f)
            {
                Debug.Log("Casella " + terreny[i].name);
                return terreny[i].transform.position;
            }
        }*/
        return new Vector3(0, 0, 0);
    }

    public void posaTorreta(Vector3 position, string type)
    {

    }
    
}
