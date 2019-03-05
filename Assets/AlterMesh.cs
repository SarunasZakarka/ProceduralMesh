using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Vertex
{
    public int id;
    public Vector3 pos;

    public Vertex(int _id, Vector3 _pos)
    {
        id = _id;
        pos = _pos;
    }
}

public class AlterMesh : MonoBehaviour {

    int xSize, ySize, zSize;

    List<List<Vertex>> frontSideVer;
    List<List<Vertex>> backSideVer;
    List<List<Vertex>> rightSideVer;
    List<List<Vertex>> leftSideVer;
    List<List<Vertex>> topSideVer;
    List<List<Vertex>> botSideVer;

    Vector3[] vertices;

    public void Alter(GameObject obj, int _xSize, int _ySize, int _zSize)
    {

        xSize = _xSize;
        ySize = _ySize;
        zSize = _zSize;

        frontSideVer = new List<List<Vertex>>(ySize);
        backSideVer = new List<List<Vertex>>(ySize);
        rightSideVer = new List<List<Vertex>>(ySize);
        leftSideVer = new List<List<Vertex>>(ySize);
        topSideVer = new List<List<Vertex>>(zSize);
        botSideVer = new List<List<Vertex>>(zSize);

        Mesh mesh = obj.GetComponent<MeshFilter>().sharedMesh;
        vertices = mesh.vertices;

        int ring = xSize * 2 + zSize * 2;
        int sideVertices = ring * (ySize+1);

        int vertToCheck = vertices.Length - ((xSize - 1) * (zSize - 1))*2;

        int vert = 0;
        float step = 4*Mathf.PI / (float)ySize;

        for (int y = 0; y <= ySize; y++)
        {
            frontSideVer.Add(AddVertexRow(ref vert, vertices,xSize));
            rightSideVer.Add(AddVertexRow(ref vert, vertices, zSize));
            backSideVer.Add( AddVertexRow(ref vert, vertices, xSize));
            leftSideVer.Add(AddVertexRow(ref vert, vertices, zSize));
           
        }
        for (int z = 0; z < zSize-1; z++)
        {
            topSideVer.Add(AddVertexRow(ref vert, vertices, xSize - 2, true));
        }

        for (int z = 0; z < zSize-1; z++)
        {
            botSideVer.Add(AddVertexRow(ref vert, vertices, xSize - 2, true));
        }


        for (int y = 0; y <= ySize; y++)
        {
            float amountToAddZ = (Mathf.Sin(step * y) * 10);
            float amountToAddX = (Mathf.Cos(step * y) * 10);

            for (int v = 0; v < frontSideVer[v].Count; v++)
            {
                AdjustVertex(frontSideVer[y][v], amountToAddX, 0, amountToAddZ);
                AdjustVertex(backSideVer[y][v], amountToAddX, 0, amountToAddZ);
            }
            for (int v = 0; v < rightSideVer[v].Count; v++)
            {
                AdjustVertex(rightSideVer[y][v], amountToAddX, 0, amountToAddZ);
                AdjustVertex(leftSideVer[y][v], amountToAddX, 0, amountToAddZ);
            }
            if (y == 0)
            {
                AdjustPlane(botSideVer, amountToAddX, amountToAddZ);
            }
            else if (y == ySize)
            {
                AdjustPlane(topSideVer, amountToAddX, amountToAddZ);

            }
        }
     
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }

    void AdjustPlane(List<List<Vertex>> planeToAdjust, float amountToAddx, float amountToAddy)
    {
        foreach(List<Vertex> row in planeToAdjust)
        {
            for (int i = 0; i < row.Count; i++)
            {
                AdjustVertex(row[i], amountToAddx, 0, amountToAddy);
            }
        }
    }

    void AdjustVertex(Vertex vertex, float xToAdd, float yToAdd, float zToAdd)
    {
        int id = vertex.id;
        Vector3 temp = vertex.pos;

        vertices[id] = new Vector3(temp.x + xToAdd, temp.y+ yToAdd, temp.z + zToAdd);

    }

    List<Vertex> AddVertexRow(ref int vert, Vector3[] vertices, int loopLimit,bool plane =false)
    {
        List<Vertex> listToAdd = new List<Vertex>();
        for (int j = 0; j <= loopLimit; j++, vert++)
        {
            listToAdd.Add( new Vertex( vert,vertices[vert]));
           
        }
        if (plane == false)
            vert--;

        return listToAdd;
    }
}
