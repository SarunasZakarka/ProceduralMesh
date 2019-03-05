using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneratorControler : MonoBehaviour {

    public string path;
    public GameObject generatedObj;
    public MeshGenerator meshGenerator;
    public AlterMesh alterMesh;

    public Material material;

    public int xSize, ySize, zSize;

    public void GenerateMesh()
    {
        DestroyImmediate(generatedObj);

        generatedObj = meshGenerator.GenerateRectangle(material,xSize, ySize, zSize);
        alterMesh.Alter(generatedObj, xSize, ySize, zSize);
    }
    public GameObject GetExportObj()
    {
        return generatedObj;
    }

}
