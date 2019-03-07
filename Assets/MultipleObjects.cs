using System.Collections.Generic;
using UnityEngine;

public class MultipleObjects : MonoBehaviour {

    public CombineMeshes combineMeshes;

    public GameObject MultiplyObjects(GameObject original, int curveStrength, int objectsTimesTwo)
    {
        float rotationStep = 180;

        List<GameObject> objList = new List<GameObject> { original };

        objList = CreateNewObjs(1, original, rotationStep, objList);

        objList[0].transform.position += new Vector3(-curveStrength, 0, 0);
        objList[1].transform.position += new Vector3(curveStrength, 0, 0);

        GameObject mergedMesh = combineMeshes.CombineOBJ(objList);
        mergedMesh.transform.position = Vector3.zero;
        objList.Clear();

        rotationStep = 360 / (objectsTimesTwo*2);

        objList = CreateNewObjs(objectsTimesTwo, mergedMesh, rotationStep, objList);
        DestroyImmediate(mergedMesh);
        return combineMeshes.CombineOBJ(objList);
    }

    List<GameObject> CreateNewObjs(int count, GameObject original,float rotationStep,List<GameObject> objList )
    { 
        float currStep = 0;
        for (int i = 0; i < count; i++)
        {
            GameObject newObj = Instantiate(original, original.transform.position, original.transform.rotation);
            newObj.transform.rotation = Quaternion.Euler(0, currStep += rotationStep, 0);
            objList.Add(newObj);
        }

        return objList;
    }


}
