using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(MeshGeneratorControler), true)]
[System.Serializable]
public class MeshGeneratorInterface : Editor
{
    MeshGeneratorControler meshGeneratorControler;

    public override void OnInspectorGUI()
    {
        meshGeneratorControler = (MeshGeneratorControler)target;
        base.OnInspectorGUI();

        if (GUILayout.Button("Export", GUILayout.Width(100)))
        {
            if (!String.IsNullOrEmpty(meshGeneratorControler.path))
            {
                ObjExporter.DoExport(false, meshGeneratorControler.GetExportObj(), meshGeneratorControler.path);

            }
        }
        if (GUILayout.Button("Generate Mesh", GUILayout.Width(100)))
        {
            meshGeneratorControler.GenerateMesh();
        }
    }
}
