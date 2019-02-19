using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneratorControler : MonoBehaviour {

    public string path;
    public GameObject generatedObj;

	public void GenerateMesh()
    {
        generatedObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }
    public GameObject GetExportObj()
    {
        return generatedObj;
    }

}
