using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casella : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public bool hihaTorre;

    public void OmpleCasella(GameObject go)
    {
        x = go.gameObject.transform.position.x;
        y = go.gameObject.transform.position.y;
        z = go.gameObject.transform.position.z;
        hihaTorre = false;
       
    }

    public void isTorre()
    {
        hihaTorre = true;
    }
}
