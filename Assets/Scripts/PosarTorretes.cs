using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosarTorretes : MonoBehaviour
{

    public float distancia = 1;
  
    public GameObject UI_Missatge;
    public GameObject UI_torres;
    public GameObject inventari;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            
            Vector3 position = transform.position;

            position.y = 0;

            GameObject casella = buscarCasella(position);
            GameObject way = buscarWay(position);

            UI_torres.GetComponent<UI_Torres>().guardaPosition(casella, way);
            UI_torres.GetComponent<UI_Torres>().guardaInventari(inventari);
            //Menu d'escollir torre
            UI_torres.SetActive(true);

        }


    }

    public GameObject buscarWay(Vector3 position)
    {

        GameObject[] terreny;
        GameObject terrenyFinal = new GameObject();

        terreny = GameObject.FindGameObjectsWithTag("Way");
        float minDist = Mathf.Infinity;

        //Debug.Log("Terreny Length" + terreny.Length);
        for (int i = 0; i < terreny.Length; i++)
        {
            float dist = Vector3.Distance(terreny[i].transform.position, position);
            if (dist < minDist)
            {
                terrenyFinal = terreny[i];
                minDist = dist;
            }

        }
        //Debug.Log("Caslla final " + terrenyFinal.name);
        return terrenyFinal;
    }

    public GameObject buscarCasella(Vector3 position)
    {

        GameObject[] terreny;
        GameObject terrenyFinal = new GameObject();

        terreny = GameObject.FindGameObjectsWithTag("Ground");
        float minDist = Mathf.Infinity;

        //Debug.Log("Terreny Length" + terreny.Length);
        for (int i = 0; i < terreny.Length; i++)
        {
            float dist = Vector3.Distance(terreny[i].transform.position, position);
            if (dist < minDist)
            {
                terrenyFinal = terreny[i];
                minDist = dist;
            }

        }
        //Debug.Log("Caslla final " + terrenyFinal.name);
        return terrenyFinal;
    }
}

   



