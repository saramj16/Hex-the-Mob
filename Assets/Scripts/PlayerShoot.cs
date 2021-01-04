using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Transform pivotArma;
    public Transform puntBales;
    private Transform target;

    public GameObject balaPrefab;
    public Camera cam;
    public Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        //int layerMask = 1 << 30;
        //layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()

    {
        //Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.yellow);
        if (Input.GetKeyUp(KeyCode.H))
        {
            /**
             Debug.Log("Ha disparat");
             target = cam.transform.forward;
             Debug.DrawRay(transform.position, target, Color.yellow, 5f);
             int layerMask = 1 << 30;
             layerMask = ~layerMask;
             RaycastHit hit;
             //LayerMask.GetMask("HitTest")
             if (Physics.Raycast(transform.position, target, out hit, Mathf.Infinity, layerMask))
             {
                 var localHit = transform.InverseTransformPoint(hit.point);
                 Debug.DrawLine(cam.transform.position, localHit, Color.red, 5f);
                 Debug.Log("Did Hit");
             }
            **/
            //Debug.Log("Ha disparat");
            RaycastHit hit;
            var ray = new Ray(cam.transform.position, cam.transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red, 5f);
                    Dispara();
                }
            }

        }
    }

    void Dispara()
    {
        GameObject balaGO = (GameObject)Instantiate(balaPrefab, puntBales.position, puntBales.rotation);
        Bala bala = balaGO.GetComponent<Bala>();

        if (bala != null)
            bala.Target(target);

    }
}
