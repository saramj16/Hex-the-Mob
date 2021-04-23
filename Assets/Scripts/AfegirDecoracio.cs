using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class AfegirRecursos : EditorWindow
{

    [MenuItem("Window/Afegir Recursos")]
    public static void ShowWindow()
    {
        GetWindow<AfegirRecursos>("Afegir Recursos");
    }

    void OnGUI()
    {

        GUILayout.Label("Afegir recursos del Mapa");

        EditorGUILayout.Space();
        GUILayout.Label("Afegir recursos del bioma d'Aigua");
 
        if (GUILayout.Button("Posa Roca 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Earth_Biome/Earth_Deco1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Roca 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Earth_Biome/Earth_Deco2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Roca 3"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Earth_Biome/Earth_Deco3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Earth_Biome/Earth_Tree1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Earth_Biome/Earth_Tree2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 3"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Earth_Biome/Earth_Tree3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        EditorGUILayout.Space();
        GUILayout.Label("Afegir recursos del bioma de Foc");
  
        if (GUILayout.Button("Posa Bolet 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Fire_Biome/Fire_Deco1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Bolet 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Fire_Biome/Fire_Deco2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Bolets 3"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Fire_Biome/Fire_Deco3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Fire_Biome/Fire_Tree1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Fire_Biome/Fire_Tree2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 3"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Fire_Biome/Fire_Tree3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        EditorGUILayout.Space();
        GUILayout.Label("Afegir recursos del bioma d'Aigua");

        if (GUILayout.Button("Posa Planteta 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Water_Biome/Water_Deco1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Planteta 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Water_Biome/Water_Deco2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Bambú"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Water_Biome/Water_Deco3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Palmera 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Water_Biome/Water_Tree1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Palmera 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Water_Biome/Water_Tree2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Palmera 3"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Water_Biome/Water_Tree3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        EditorGUILayout.Space();
        GUILayout.Label("Afegir recursos del bioma d'Aire");

        if (GUILayout.Button("Posa Planteta 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Wind_Biome/Wind_Deco1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Planteta 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Wind_Biome/Wind_Deco2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Roca Petita"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Wind_Biome/Wind_Deco3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 1"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Wind_Biome/Wind_Tree1"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Arbre 2"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Wind_Biome/Wind_Tree2"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (GUILayout.Button("Posa Roca Gran"))
        {
            GameObject[] obj = Selection.gameObjects;
            for (int i = 0; i < obj.Length; i++)
            {

                Vector3 pos = buscaAltura(obj[i].gameObject);

                Instantiate(Resources.Load("Decoration/Wind_Biome/Wind_Tree3"), pos, Quaternion.Euler(0, 0, 0));
            }
        }

    }

    private Vector3 buscaAltura(GameObject obj)
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

        return position;
    }

}
#endif