using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanviarCam : MonoBehaviour
{
    public Camera cam1, cam2;
    public Cursor cursor;
    GameObject[] torres;
    List <GameObject> ranges;
    int numRanges;
    public Material rangeMaterial, minRangeMaterial;
    void Start()
    {
        cam2 = GameObject.Find("Camera").GetComponent<Camera>();
        cam1 = GameObject.Find("Camera Top").GetComponent<Camera>();
        cam1.enabled = false;
        cam2.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cursor.top = !cursor.top;
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
            ManageTopView();
        }
    }

    void ManageTopView()
    {
        //Obtenir torretes
        torres = GameObject.FindGameObjectsWithTag("Torre");

        if (cam1.enabled)
        {
            numRanges = torres.Length;
            for (int i = 0; i < torres.Length; i++)
            {
                if (torres[i].GetComponent<Turret>().minRange>0)
                {
                    numRanges++;
                }
            }
            ranges = new List <GameObject>();
            //Dibuixar ranges
            for (int i = 0; i < torres.Length; i++)
            {
                Turret currentTurret = torres[i].GetComponent<Turret>();
                if (currentTurret.minRange > 0)
                {
                    ranges.Add(GameObject.CreatePrimitive(PrimitiveType.Cylinder));
                    ranges[ranges.Count - 1].transform.position = new Vector3(torres[i].transform.position.x, torres[i].transform.position.y + 0.05f, torres[i].transform.position.z);
                    Destroy(ranges[ranges.Count - 1].GetComponent<CapsuleCollider>());
                    ranges[ranges.Count - 1].transform.localScale = new Vector3(currentTurret.minRange*2, 0.02f, currentTurret.minRange*2);
                    ranges[ranges.Count - 1].GetComponent<MeshRenderer>().material = minRangeMaterial;
                }
                
                ranges.Add(GameObject.CreatePrimitive(PrimitiveType.Cylinder));
                ranges[ranges.Count - 1].transform.position = torres[i].transform.position;
                Destroy(ranges[ranges.Count - 1].GetComponent<CapsuleCollider>());
                ranges[ranges.Count - 1].transform.localScale = new Vector3(currentTurret.range*2, 0.02f, currentTurret.range*2);
                ranges[ranges.Count - 1].GetComponent<MeshRenderer>().material = rangeMaterial;
         
            }


        } else
        {
            //Esborrar ranges
            for (int i = 0; i < numRanges; i++)
            {
                Destroy(ranges[i]);



            }
        }
    }

}