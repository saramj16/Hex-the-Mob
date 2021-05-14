using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class EditorMapa : EditorWindow
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
        GetWindow<EditorMapa>("Editor Mapa");
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
 

                obj[i].gameObject.transform.localScale = obj[i].gameObject.transform.localScale + new Vector3(0, 0, 0.2f);
                //obj[i].gameObject.transform.position = obj[i].gameObject.transform.position + new Vector3(0, 0.15f, 0);

            }
        }

        // Si volen convertir-los en ground
        if (GUILayout.Button("Baixa els HEXAGONS SELECCIONATS"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].gameObject.transform.localScale = obj[i].gameObject.transform.localScale - new Vector3(0, 0, 0.2f);
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




        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        // Si volen convertir-los en ground
        if (GUILayout.Button("Canviar HEXAGONS"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                // Per cada HEXAGON 
                float x = obj[i].gameObject.transform.position.x;
                float y = 0;
                float z = obj[i].gameObject.transform.position.z;
                //Hem de canviar l'HEXAGON posant una Tapa de dalt i posant els costats
                int numVertices = obj[i].GetComponent<MeshCollider>().sharedMesh.vertices.Length;
     
                float altura = buscaAltura(obj[i]);
                float alturaMinima = buscaAlturaMinima(obj[i]);
                //Vull la mida més alta i la més baixa.


                Instantiate(Resources.Load("TopHex"), new Vector3(x, altura, z), Quaternion.Euler(-90, 0, 0));
                Instantiate(Resources.Load("Hex_V3"), new Vector3(x, altura - 0.4f, z), Quaternion.Euler(-90, 0, 0));
                float alturaActual = altura - 0.4f;
                while(alturaActual > alturaMinima)
                {
                    Instantiate(Resources.Load("Hex_V3"), new Vector3(x, alturaActual -0.395f, z), Quaternion.Euler(-90, 0, 0));
                    alturaActual = alturaActual - 0.395f;
                }

                //Un cop posat el primer costat, hem de mirar si ja hem arribat a baix de tot, sino pos seguir posant objecte
                DestroyImmediate(obj[i]);
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        // Si volen convertir-los en ground
        if (GUILayout.Button("Canviar HEXAGONS darrere MUNTANYA AIGUA"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                // Per cada HEXAGON 
                Vector3 position = obj[i].gameObject.transform.position;
                Vector3 scale = obj[i].gameObject.transform.localScale;
                scale.x = 1;
                scale.y = 1;
                

                float altura = buscaAltura(obj[i]);

                //Vull la mida més alta i la més baixa.
                
                
                GameObject o = (GameObject)Instantiate(Resources.Load("HexSup3"), position, Quaternion.Euler(-90, 0, 0));
                o.gameObject.transform.localScale = scale;

                //Un cop posat el primer costat, hem de mirar si ja hem arribat a baix de tot, sino pos seguir posant objecte
                DestroyImmediate(obj[i]);
            }
        }


        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        // Si volen convertir-los en ground
        if (GUILayout.Button("Canviar HEXAGONS darrere MUNTANYA FOC"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                // Per cada HEXAGON 
                Vector3 position = obj[i].gameObject.transform.position;
                Vector3 scale = obj[i].gameObject.transform.localScale;
                scale.x = 1;
                scale.y = 1;
                //Vull la mida més alta i la més baixa.

                GameObject o = (GameObject)Instantiate(Resources.Load("HexSup1"), position, Quaternion.Euler(-90, 0, 0));
                o.gameObject.transform.localScale = scale;

                //Un cop posat el primer costat, hem de mirar si ja hem arribat a baix de tot, sino pos seguir posant objecte
                DestroyImmediate(obj[i]);
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        // Si volen convertir-los en ground
        if (GUILayout.Button("Canviar HEXAGONS darrere MUNTANYA EARTH"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                // Per cada HEXAGON 
                Vector3 position = obj[i].gameObject.transform.position;
                Vector3 scale = obj[i].gameObject.transform.localScale;
                scale.x = 1;
                scale.y = 1;
                //Vull la mida més alta i la més baixa.

                GameObject o = (GameObject)Instantiate(Resources.Load("HexSup4"), position, Quaternion.Euler(-90, 0, 0));
                o.gameObject.transform.localScale = scale;

                //Un cop posat el primer costat, hem de mirar si ja hem arribat a baix de tot, sino pos seguir posant objecte
                DestroyImmediate(obj[i]);
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        // Si volen convertir-los en ground
        if (GUILayout.Button("Canviar HEXAGONS darrere MUNTANYA AIR"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                // Per cada HEXAGON 
                Vector3 position = obj[i].gameObject.transform.position;
                Vector3 scale = obj[i].gameObject.transform.localScale;
                scale.x = 1;
                scale.y = 1;
                //Vull la mida més alta i la més baixa.

                GameObject o = (GameObject)Instantiate(Resources.Load("HexSup5"), position, Quaternion.Euler(-90, 0, 0));
                o.gameObject.transform.localScale = scale;

                //Un cop posat el primer costat, hem de mirar si ja hem arribat a baix de tot, sino pos seguir posant objecte
                DestroyImmediate(obj[i]);
            }
        }
    }

    private float buscaAlturaMinima(GameObject obj)
    {
        float altura = 0;

        LayerMask mask = LayerMask.GetMask("Terra");

        RaycastHit hit;
        Vector3 aux = obj.transform.position;
        aux.y = -1000f;
        if (Physics.Raycast(aux, obj.transform.forward * 1000f, out hit, Mathf.Infinity, mask))
        {
            Debug.DrawRay(aux, obj.transform.forward * 1000f, Color.black);
            altura = hit.point.y;
        }

        Vector3 position = obj.transform.position;
        position.y = altura;
        Debug.Log("Altura minima: " + altura);
        return altura;
    }
    private float buscaAltura(GameObject obj)
    {
        float altura = 0;

        LayerMask mask = LayerMask.GetMask("Terra");

        RaycastHit hit;
        Vector3 aux = obj.transform.position;
        aux.y = 300f;
        if (Physics.Raycast(aux, -obj.transform.forward * 1000f, out hit, Mathf.Infinity, mask))
        {
            altura = hit.point.y;
        }

        Vector3 position = obj.transform.position;
        position.y = altura;

        return altura;
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
#endif