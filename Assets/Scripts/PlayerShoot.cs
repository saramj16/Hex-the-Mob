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

    public GameObject cursor;
   // public UI_Inventory inventory;
    public UI_InGame inventory;

    public bool potDisparar;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate=1;
    private float timer;

    [SerializeField]
    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        potDisparar = true;
        bulletSpeed = 10f;
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
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

                inventory.RefreshInventoryItems();
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

    public void DesactivaCursor()
    {
        Debug.Log("Desactivem Cursor");
        potDisparar = false;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        cursor.SetActive(false);
    }

    private void ActivaPotDispara()
    {
        //Debug.Log("Pot disparar");
        potDisparar = true;
    }
    public void ActivaCursor()
    {
        Debug.Log("Activem Cursor");
        Invoke("ActivaPotDispara", 1.5f);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        cursor.SetActive(true);
    }
    private void bruixaDispara()
    {
        Vector3 miradaAuxiliar = cam.transform.forward;
        miradaAuxiliar.y = 0;

        this.gameObject.transform.forward = miradaAuxiliar.normalized;

        Ray ray = cam.ViewportPointToRay(Vector3.one*0.5f);
        RaycastHit hitInfo;
        LayerMask layer = LayerMask.GetMask("ColliderCami");
        layer |= LayerMask.GetMask("Personatge");
        
        if (Physics.Raycast(ray, out hitInfo, 100, ~layer))
        {
            Debug.Log("La bruixaa xoca contra: " + hitInfo.collider.gameObject.name);
            if (potDisparar)
            {
                // Aqui haurem de fer que resti les bales al inventari de bales
                int numBales = int.Parse(inventory.nBales.text);
                if(numBales > 0)
                {
                    GameObject bulletClone = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    Debug.DrawRay(firePoint.position, hitInfo.point - firePoint.position, Color.blue, 3f);
                    bulletClone.GetComponent<BalaBruixa>().setTargetDirection(hitInfo.point - firePoint.position);
                    inventory.RefreshInventoryItems();
                    inventory.carregaBales.GetComponent<UI_CarregaBales>().bales--;
                }
              
            }

        }
    }

}
