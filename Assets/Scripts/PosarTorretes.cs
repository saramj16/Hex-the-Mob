using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosarTorretes : MonoBehaviour
{

    public float distancia = 1;
    public GameObject torre;
  
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
            Vector3 direction = transform.forward;
            //Debug.Log("Position " + position);
            //Debug.Log("Direction " + direction);
            RaycastHit hit;

            int layerMask = 1 << 8;
            //layerMask = ~layerMask;

            Debug.DrawRay(position, direction * distancia, Color.yellow, 5f);
            if (Physics.Raycast(position, direction, out hit, distancia, layerMask))
            {
                Debug.DrawRay(position, direction*distancia, Color.green, 5f);
                //hit.transform.position;
                Vector3 torreta = buscarTorreta(hit.transform.position);
                torreta.y = 2;
                posaTorreta(torreta, "Normal");
            }
        }
    }

    public Vector3 buscarTorreta(Vector3 puntCollision)
    {
        //Debug.Log("Entra aqui");
        GameObject[] terreny;
        terreny = GameObject.FindGameObjectsWithTag("Terreny");

        for (int i = 0; i < terreny.Length; i++)
        {
            if (Vector3.Distance(puntCollision, terreny[i].transform.position) < 1f)
            {
                Debug.Log("Casella " + terreny[i].name);
                return terreny[i].transform.position;
            }
        }
        return new Vector3(0, 0, 0);
    }

    public void posaTorreta(Vector3 position, string type)
    {
        Debug.Log("Entra aqui");
        Instantiate(torre, position, Quaternion.identity);
    }


}
