using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class EditorMaterials : EditorWindow
{

    int h = 0;
    int v = 0;

    static float x = 0, y = 0, z = 0;

    public void Start()
    {
        Debug.Log("Entra");
        
    }

    [MenuItem("Window/Editor Materials")]
    public static void ShowWindow()
    {
        GetWindow<EditorMaterials>("Editor Materials");
    }

    void OnGUI()
    {

        GUILayout.Label("Canvia els materials dels Hexagons");
        // Caselles per posar el numero de caselles horitzontals i verticals
       
        // Si volen convertir-los en EARTH
        if (GUILayout.Button("Posa Material EARTH"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].transform.position;
                Vector3 scale = obj[i].transform.localScale;

                DestroyImmediate(obj[i]);
                GameObject o = (GameObject)Instantiate(Resources.Load("HexagonEARTH"), position, Quaternion.Euler(-90, 0, 0));
                o.transform.localScale = scale;

            }
        }

        // Si volen convertir-los en AIR
        if (GUILayout.Button("Posa Material AIR"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].transform.position;
                Vector3 scale = obj[i].transform.localScale;

                DestroyImmediate(obj[i]);
                GameObject o = (GameObject)Instantiate(Resources.Load("HexagonAIR"), position, Quaternion.Euler(-90, 0, 0));
                o.transform.localScale = scale;

            }
        }

        // Si volen convertir-los en WATER
        if (GUILayout.Button("Posa Material WATER"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].transform.position;
                Vector3 scale = obj[i].transform.localScale;

                DestroyImmediate(obj[i]);
                GameObject o = (GameObject)Instantiate(Resources.Load("HexagonWATER"), position, Quaternion.Euler(-90, 0, 0));
                o.transform.localScale = scale;

            }
        }

        // Si volen convertir-los en FIRE
        if (GUILayout.Button("Posa Material FIRE"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].transform.position;
                Vector3 scale = obj[i].transform.localScale;

                DestroyImmediate(obj[i]);
                GameObject o = (GameObject)Instantiate(Resources.Load("HexagonFIRE"), position, Quaternion.Euler(-90, 0, 0));
                o.transform.localScale = scale;

            }
        }

        // Si volen convertir-los en PEDRA
        if (GUILayout.Button("Posa Material PEDRA"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].transform.position;
                Vector3 scale = obj[i].transform.localScale;

                DestroyImmediate(obj[i]);
                GameObject o = (GameObject)Instantiate(Resources.Load("HexagonPEDRA"), position, Quaternion.Euler(-90, 0, 0));
                o.transform.localScale = scale;

            }
        }

        // Si volen convertir-los en CAMÍ
        if (GUILayout.Button("Posa Material CAMÍ"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {
                Vector3 position = obj[i].transform.position;
                Vector3 scale = obj[i].transform.localScale;

                DestroyImmediate(obj[i]);
                GameObject o = (GameObject)Instantiate(Resources.Load("HexagonCAMI"), position, Quaternion.Euler(-90, 0, 0));
                o.transform.localScale = scale;

            }
        }

        EditorGUILayout.Space();
        GUILayout.Label("Afegeix elements de decoració del MAPA");
        if (GUILayout.Button("Posa NOM_DEL_RECURS"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                float altura = 0;

                LayerMask mask = LayerMask.GetMask("Terra");

                RaycastHit hit;
                Vector3 aux = obj[i].transform.position;
                aux.y = 300f;
                if (Physics.Raycast(aux, -obj[i].transform.forward * 1000f, out hit, Mathf.Infinity, mask))
                {
                    altura = hit.point.y;
                }

                Vector3 position = obj[i].transform.position;
                position.y = altura;
   
                Instantiate(Resources.Load("NOM_DEL_RECURS"), position, Quaternion.Euler(0, 0, 0));


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
#endif