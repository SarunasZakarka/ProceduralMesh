using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDebuging : MonoBehaviour {

   /* private void OnDrawGizmos()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            Debug.Log(normals[i]);
            Gizmos.color = Color.red;
            Vector3 direction = transform.TransformDirection(normals[i]) * 5;
            Gizmos.DrawRay(transform.position, direction);
        }

        /*  if (vertices == null)
          {
              return;
          }
          Gizmos.color = Color.black;
          for (int i = 0; i < vertices.Length; i++)
          {
              Gizmos.DrawSphere(vertices[i], 0.1f);
          }
    }

    // Update is called once per frame
    void Update () {
		
	}*/
}
