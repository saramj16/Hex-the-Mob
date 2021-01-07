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


            UI_torres.GetComponent<UI_Torres>().guardaPosition(casella);
            UI_torres.GetComponent<UI_Torres>().guardaInventari(inventari);
            //Menu d'escollir torre
            UI_torres.SetActive(true);



        }

        

        //Prova per si funciona amb el raycast des de la camera
        /*if (Input.GetKeyUp(KeyCode.G))
        {
            RaycastHit hit;
            int layerMask = 1 << 8; 
            Vector3 position = transform.position;
            Vector3 direction = transform.forward;
            //layerMask = ~layerMask;

            Debug.DrawRay(position, direction * distancia, Color.yellow, 5f);
            if (Physics.Raycast(position, direction, out hit, distancia, layerMask))
            {
                Debug.DrawRay(position, direction*distancia, Color.green, 5f);
                //hit.transform.position;
                //Vector3 torreta = buscarTorreta(hit.transform.position);
                //torreta.y = 2;
                
            }
        }*/
        //posaTorreta(torreta, "Normal");

    }


        // TO-DO: poder eliminar o canviar torretes (Com les volem seleccionar?)

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

   



