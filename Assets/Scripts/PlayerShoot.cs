using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera cam;
    //public Collider collider;
    float bulletSpeed;
    public Rigidbody bullet;

    public Inventory inventari;
    public UI_Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 10f;
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        //int layerMask = 1 << 30;
        //layerMask = ~layerMask;
        inventari = inventory.GetInventory();
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
                    Dispara(hit.point);
                }
            }

        }
    }

    void Dispara(Vector3 punt)
    {
        
        if (inventari.spendResourcesDisparo())
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
            Vector3 dir = punt - transform.position;
            bulletClone.velocity = dir.normalized * bulletSpeed;
            inventory.RefreshInventoryItems();
        }
        
    }
}
