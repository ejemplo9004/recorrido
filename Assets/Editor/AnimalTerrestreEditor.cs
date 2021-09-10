using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimalTerrestre))]
public class AnimalTerrestreEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AnimalTerrestre at = (AnimalTerrestre)target;
        base.OnInspectorGUI();
        if (GUILayout.Button("Crear checkpoints"))
        {
            at.CrearChecPoints();
        }
        if (GUILayout.Button("Aplanar checkpoints"))
        {
            at.AplanarCheckpoints();
        }
    }
}
