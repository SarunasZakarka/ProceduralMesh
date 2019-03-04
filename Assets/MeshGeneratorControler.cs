using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneratorControler : MonoBehaviour {

    public string path;
    public GameObject generatedObj;
    public MeshGenerator meshGenerator;
    public Material material;

	public void GenerateMesh()
    {
        DestroyImmediate(generatedObj);
        generatedObj = meshGenerator.GenerateRectangle(material);
    }
    public GameObject GetExportObj()
    {
        return generatedObj;
    }

}
