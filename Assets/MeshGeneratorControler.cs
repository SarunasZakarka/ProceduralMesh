using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneratorControler : MonoBehaviour {

    public string path;
    public GameObject generatedObj;
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
    public bool singleObject;
    [Range(1, 20)]
    public int objectsTimesTwo;

    public void GenerateMesh()
    {
        DestroyImmediate(generatedObj);

        generatedObj = new MeshGenerator().GenerateRectangle(material,xSize, ySize, zSize);
        new AlterMesh().Alter(generatedObj, xSize, ySize, zSize, curvesCount, curveWidth, spiral, curveStrength);
        if(singleObject == false)
        {
            generatedObj = multipleObjects.MultiplyObjects(generatedObj, curveStrength, objectsTimesTwo);
        }
    }
    public GameObject GetExportObj()
    {
        return generatedObj;
    }


}
