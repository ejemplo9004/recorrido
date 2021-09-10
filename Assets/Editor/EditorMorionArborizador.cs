using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MorionArborizador))]
public class EditorMorionArborizador : Editor
{
    public bool fabricable = true;
    
    

    private void OnEnable() => SceneView.onSceneGUIDelegate += DuringSceneView;
    private void OnDisable() => SceneView.onSceneGUIDelegate -= DuringSceneView;

    public override void OnInspectorGUI()
    {
        MorionArborizador morion = (MorionArborizador)target;
        
        GUIStyle gsTest = new GUIStyle();

        if (morion.objetos!=null && morion.objetos.Length>0)
        {
            morion.indice = Mathf.RoundToInt(Mathf.Clamp(morion.indice, 0, morion.objetos.Length - 1));

            Texture2D image = AssetPreview.GetAssetPreview(morion.objetos[morion.indice]);
            void CambiarFondo(Texture2D fondo)
            {
                GUI.skin.button.normal.background = fondo;
                GUI.skin.button.hover.background = fondo;
                GUI.skin.button.active.background = fondo;
            }
            CambiarFondo(image);
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Button("", GUILayout.Width(100), GUILayout.Height(100));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            CambiarFondo(null);

            for (int i = 0; i < morion.objetos.Length; i++)
            {
                GUILayout.BeginHorizontal(gsTest);
                GUIStyle st = new GUIStyle(GUI.skin.button);
                if (morion.indice == i)
                {
                    st.normal.textColor = Color.green;
                }
                if (GUILayout.Button(morion.objetos[i].name, st))
                {
                    morion.indice = i;
                }
                GUILayout.EndHorizontal();
            }

        }

        base.OnInspectorGUI();
    }

    void DuringSceneView(SceneView sceneView)
    {


        Transform camTf = sceneView.camera.transform;
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        if (Event.current.type == EventType.MouseMove)
        {
            sceneView.Repaint();
        }




        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            Handles.color = Color.black;
            fabricable = (Vector3.Dot(hit.normal, Vector3.up) > 0.5f);
            if (!fabricable)
            {
                Handles.color = Color.red;
            }

            Handles.DrawAAPolyLine(4, hit.point, hit.point + hit.normal * 10);
            Handles.DrawWireDisc(hit.point, hit.normal, 2);
            Handles.DrawWireDisc(hit.point, hit.normal, 2.5f);
            Handles.DrawWireDisc(hit.point, hit.normal, 1.5f);

            if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && !Event.current.alt && fabricable)
            {
                CrearArbol(hit.point, hit.normal);
            }
            if (Event.current.type == EventType.Layout)
            {
                
                HandleUtility.AddDefaultControl(0);
            }
        }


    }

    public void CrearArbol(Vector3 pos, Vector3 normal)
    {
        MorionArborizador morion = (MorionArborizador)target;
        GameObject go = PrefabUtility.InstantiatePrefab(morion.objetos[morion.indice]) as GameObject;
        go.transform.parent = morion.transform;
        go.transform.position = pos;
        if (morion.orientarNormal)
        {
            go.transform.up = normal;
        }
        else
        {
            go.transform.up = Vector3.up;
        }
        go.transform.Rotate(Vector3.up * Random.Range(0, 360));
        Undo.RegisterCreatedObjectUndo(go, "Creó un árbol: " + go.name);
    }


}
