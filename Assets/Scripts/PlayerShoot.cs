using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera cam;
    //public Collider collider;
    float bulletSpeed;
    public GameObject bullet;

    public Inventory inventari;
   // public UI_Inventory inventory;
    public UI_InGame inventory;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate=1;
    private float timer;

    [SerializeField]
    private Transform firePoint;

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
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                timer = 0f;
                bruixaDispara();
                /**
         
                
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
                **/
            }
        }
        
    }
    private void bruixaDispara()
    {
        Ray ray = cam.ViewportPointToRay(Vector3.one*0.5f);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            //Destroy(hitInfo.collider.gameObject);
            if (inventari.spendResourcesDisparo())
            {
                GameObject bulletClone = Instantiate(bullet, firePoint.position, firePoint.rotation);
                Debug.DrawRay(firePoint.position, hitInfo.point - firePoint.position, Color.blue, 3f);
                bulletClone.GetComponent<BalaBruixa>().setTargetDirection(hitInfo.point - firePoint.position);
                inventory.RefreshInventoryItems();
            }

        }
    }

}
