using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{

    int h = 0;
    int v = 0;

    static float x = 0, y = 0, z = 0;

    public void Start()
    {
        Debug.Log("Entra");
        
    }

    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/Editor Mapa")]
    public static void ShowWindow()
    {
        GetWindow<MyWindow>("Editor Mapa");


    }

    void OnGUI()
    {

        GUILayout.Label("Posa les mesures del mapa i crea'l");
        // Caselles per posar el numero de caselles horitzontals i verticals
        h = EditorGUILayout.IntField("Horizontal", h);
        v = EditorGUILayout.IntField("Vertical", v);

        // Quan apreten el boto posem els hexagons
        if (GUILayout.Button("Posa terra"))
        {
            PlaceHexs(h,v);
        }

        EditorGUILayout.Space();

        GUILayout.Label("Selecciona els hexagons que vulguis convertir en WAY");
        // Si volen convertir-los en camí
        if (GUILayout.Button("Converteix en WAY"))
        {
            GameObject[] obj = Selection.gameObjects;
            for(int i = 0; i < obj.Length; i++) {
                Vector3 position = obj[i].gameObject.transform.position;
                DestroyImmediate(obj[i]);
                GameObject o;
                o = (GameObject)Instantiate(Resources.Load("CamiPrefab"), position, Quaternion.Euler(270, 0, 0));
                GameObject[] way = GameObject.FindGameObjectsWithTag("WayEditor");
                o.transform.SetParent(way[0].transform);
                Instantiate(Resources.Load("Waypoint"), position, Quaternion.identity);
            }
        }

        GUILayout.Label("Selecciona els hexagons que vulguis convertir en GROUND");
        // Si volen convertir-los en ground
        if (GUILayout.Button("Converteix en GROUND"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].gameObject.transform.position;
                DestroyImmediate(obj[i]);

                GameObject o;
                o = (GameObject)Instantiate(Resources.Load("Hexagon"), position, Quaternion.Euler(270, 0, 0));

                GameObject[] ground = GameObject.FindGameObjectsWithTag("GroundEditor");
                o.transform.SetParent(ground[0].transform);

            }
        }

        GUILayout.Label("Selecciona el waypoint que vulguis convertir en spawn point");
        // Fer un boto per canviar un waypoint per spawn point
        if (GUILayout.Button("Converteix en spawn point"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].gameObject.transform.position;
                DestroyImmediate(obj[i]);
                Instantiate(Resources.Load("Spawn_point"), position, Quaternion.identity);
            }
        }

        EditorGUILayout.Space();
        GUILayout.Label("Selecciona el hexagon on vulguis posar el Hexentrum");
        // Per posar la torre de la bruixa
        if (GUILayout.Button("Posa el Hexentrum"))
        {
            GameObject[] obj = Selection.gameObjects;

            Vector3 position = obj[0].gameObject.transform.position;
            Instantiate(Resources.Load("HexenturmTower"), position, Quaternion.Euler(-90, 0, 0));

        }


        EditorGUILayout.Space();
        GUILayout.Label("Selecciona el hexagon on vulguis posar el Pont");
        // Per posar la torre de la bruixa
        if (GUILayout.Button("Posa el Pont"))
        {
            GameObject[] obj = Selection.gameObjects;

            Vector3 position = obj[0].gameObject.transform.position;
           // Instantiate(Resources.Load("HexenturmTower"), position, Quaternion.Euler(-90, 0, 0));

        }



        EditorGUILayout.Space();
        GUILayout.Label("Selecciona els hexagons que vulguis moure");
        // Si volen convertir-los en ground
        if (GUILayout.Button("Puja els HEXAGONS SELECCIONATS"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
 

                obj[i].gameObject.transform.localScale = obj[i].gameObject.transform.localScale + new Vector3(0, 0, 1.5f);
                //obj[i].gameObject.transform.position = obj[i].gameObject.transform.position + new Vector3(0, 0.15f, 0);

            }
        }

        // Si volen convertir-los en ground
        if (GUILayout.Button("Baixa els HEXAGONS SELECCIONATS"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].gameObject.transform.localScale = obj[i].gameObject.transform.localScale - new Vector3(0, 0, 1.5f);
                //obj[i].gameObject.transform.position = obj[i].gameObject.transform.position + new Vector3(0, -0.15f, 0);

            }
        }

        EditorGUILayout.Space();
        // Si volen convertir-los en ground
        if (GUILayout.Button("Baixa els HEXAGONS a la MEITAT"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                float x = obj[i].gameObject.transform.localScale.x;
                float y = obj[i].gameObject.transform.localScale.y;
                float z = obj[i].gameObject.transform.localScale.z/2f;
                obj[i].gameObject.transform.localScale = new Vector3(x, y, z);
                //obj[i].gameObject.transform.position = obj[i].gameObject.transform.position + new Vector3(0, -0.15f, 0);

            }
        }


    }

    static void PlaceHexs(int h, int v)
    {
        // Bucle en les caselles horitzontals
        for (int i = 0; i < h; i++)
        {   
            //Si es parell posem una coordenada sino una altre
            if ((i % 2) == 0)
            {
                z = 0;
            } else
            {
                z = 0.12206f;
            }
            //Bucle de les casselles verticals
            for (int j = 0; j < v; j++)
            {
                //Instanciem el prefab i augmentem la coordenada z
                Instantiate(Resources.Load("Hexagon"), new Vector3(x, y, z), Quaternion.Euler(90, 0, 0));
                z += 0.24413f;            
            }
            // Quan acaben el bucle vertical augmentem la x i seguim amb la seguent linia de caselles
            x += 0.21143f;
        }
    }


}