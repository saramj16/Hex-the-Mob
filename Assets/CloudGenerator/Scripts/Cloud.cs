using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud:MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f,2f);
        float size = Random.Range(4,8);
        transform.localScale = new Vector3(size,size,size);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other) //Quan un nuvol toca cloudDestroy, desapareix
    {
        if (other.tag == "CloudDestroy")
        {
            Destroy(gameObject);

        }
    }
}
