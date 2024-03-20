using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public interface ISetMeshData
{
    public void SetMeshData(ref Mesh mesh);
}
public class MeshGenerateReturn : ISetMeshData
{
    public Vector3[] vertices;
    public int[] triangles;

    public virtual void SetMeshData(ref Mesh mesh)
    {
        mesh.vertices = vertices;
        //mesh.triangles = triangles;
        mesh.SetIndices(triangles, MeshTopology.Triangles, 0);
    }
}

public class MeshGenerateVectorTriangleNormal : MeshGenerateReturn
{
    public Vector3[] normals;

    public override void SetMeshData(ref Mesh mesh)
    {
        base.SetMeshData(ref mesh);

        mesh.normals = normals;
    }
}
