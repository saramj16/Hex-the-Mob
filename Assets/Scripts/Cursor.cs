using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Texture cursorImage;
    Vector3 mousePos;
    public static Vector3 tmp;
    private RaycastHit hit;


    void Start()
    {
        UnityEngine.Cursor.visible = false;
    }

    void OnGUI()
    {
       
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //Rect pos = new Rect(mousePos.x, Screen.height - mousePos.y, -cursorImage.width / 2, -cursorImage.height / 2);
        Rect pos = new Rect(Screen.width/2 - 20, (Screen.height/2 - 20), 50, 63);
        //Rect pos = new Rect(mousePos.x - 20, (Screen.height - 20) - mousePos.y, 50, 63);
        GUI.Label(pos, cursorImage);
    }
}
