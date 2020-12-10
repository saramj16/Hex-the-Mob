using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanviarCam : MonoBehaviour
{
    public Camera cam1, cam2;

    void Start()
     {
        cam2 = GameObject.Find("Camera").GetComponent<Camera>();
        cam1 = GameObject.Find("Camera Top").GetComponent<Camera>();

        cam1.enabled = true;
        cam2.enabled = false;
     }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }

}
