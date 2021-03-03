using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopView : MonoBehaviour
{
    public Camera cam1, cam2;
    private List<Turret> turrets;
    // Start is called before the first frame update
    void Start()
    {
        cam2 = GameObject.Find("Camera").GetComponent<Camera>();
        cam1 = GameObject.Find("Camera Top").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam1.enabled)
        {
            //Obtenir torretes
            GameObject[] torres = GameObject.FindGameObjectsWithTag("Torre");

            for (int i = 0; i < torres.Length; i++)
            {
                //Dibuixar range
                //Gizmos.DrawWireSphere(torres[i].transform.position, torres[i].gameObject.GetComponent<Turret>().range);

            }

        }
    }
}
