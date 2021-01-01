using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{

    int h = 0;
    int v = 0;

    static float x = 0, y = 0, z = 0;


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

        GUILayout.Label("Selecciona els hexagons que vulguis convertir en camí");
        // Si volen convertir-los en camí
        if (GUILayout.Button("Converteix en cami"))
        {
            GameObject[] obj = Selection.gameObjects;
            for(int i = 0; i < obj.Length; i++) {
                Vector3 position = obj[i].gameObject.transform.position;
                DestroyImmediate(obj[i]);
                Instantiate(Resources.Load("CamiPrefab"), position, Quaternion.Euler(90, 0, 0));

                Instantiate(Resources.Load("Waypoint"), position, Quaternion.identity);
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