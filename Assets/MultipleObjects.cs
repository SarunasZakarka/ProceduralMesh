using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleObjects : MonoBehaviour {

    public List<GameObject> MultiplyObjects(GameObject original, int curveStrength)
    {
        int count = 4;
        float rotationStep = 360 / count;
        float currStep = 0;
        List<GameObject> objList = new List<GameObject> { original };

        for (int i = 1; i < count; i++)
        {
            GameObject newObj = Instantiate(original, original.transform.position, original.transform.rotation);
            newObj.transform.rotation = Quaternion.Euler(0, currStep+=rotationStep, 0);
            objList.Add(newObj);
        }
        objList[0].transform.position += new Vector3(-curveStrength, 0, 0);
        objList[1].transform.position += new Vector3(0, 0, curveStrength);
        objList[2].transform.position += new Vector3(curveStrength, 0, 0);
        objList[3].transform.position += new Vector3(0, 0, -curveStrength);


        return objList;
    }
}
