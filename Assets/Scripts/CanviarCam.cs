using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanviarCam : MonoBehaviour
{
    public Camera cam1, cam2;
    public Cursor cursor;
    GameObject[] torres;
    GameObject[] ranges;
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
            TopView();
        }
    }

    void TopView()
    {
        //Obtenir torretes
        torres = GameObject.FindGameObjectsWithTag("Torre");
        

        if (cam1.enabled)
        {
            ranges = new GameObject[torres.Length];
            //Dibuixar ranges
            for (int i = 0; i < torres.Length; i++)
            {
                Debug.Log("Torres: " +(1+i));
                ranges[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                ranges[i].transform.position = torres[i].transform.position;
                Turret currentTurret = torres[i].GetComponent<Turret>();
                float currentRange = currentTurret.range;
                Destroy(ranges[i].GetComponent<CapsuleCollider>());
                ranges[i].transform.localScale = new Vector3(currentRange,0.1f,currentRange);
            }

        } else
        {
            //Esborrar ranges
            for (int i = 0; i < torres.Length; i++)
            {
                Debug.Log("Esborrar torre: " + (1 + i));
                Destroy(ranges[i]);



            }
        }
    }

}