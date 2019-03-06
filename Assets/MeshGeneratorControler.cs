using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneratorControler : MonoBehaviour {

    public string path;
    public GameObject generatedObj;
    public MeshGenerator meshGenerator;
    public AlterMesh alterMesh;
    public CombineMeshes combineMeshes;
    public MultipleObjects multipleObjects;

    public Material material;

    public int xSize, ySize, zSize;
    [Range(1,100)]
    public int curvesCount;
    [Range(1, 3)]
    public float curveWidth;
    [Range(1, 100)]
    public int curveStrength;
    public bool spiral;

    public void GenerateMesh()
    {
        DestroyImmediate(generatedObj);

        generatedObj = meshGenerator.GenerateRectangle(material,xSize, ySize, zSize);
        alterMesh.Alter(generatedObj, xSize, ySize, zSize, curvesCount, curveWidth, spiral, curveStrength);
        combineMeshes.CombineOBJ(multipleObjects.MultiplyObjects(generatedObj, curveStrength));
    }
    public GameObject GetExportObj()
    {
        return generatedObj;
    }

}
