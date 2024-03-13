using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MeshGen<T, T1> where T : MeshParams
{
    public T Params { get; protected set; }

    public virtual Vector3 Pivot {  get; protected set; } = Vector3.zero;

    public string Name { get; protected set; }

    protected virtual (Vector3[], int[]) Generate()
    {
        //Vector2[] uv = new Vector2[4];
        Vector3[] vertices = new Vector3[] {
        
        };
        int[] triangles = new int[] {
        
        };

        return (vertices, triangles);
    }

    public virtual Mesh PostCreate(Mesh m)
    {
        return m;
    }

    public Mesh Create(T meshParams)
    {
        Params = meshParams;
        Pivot = meshParams.Pivot;

        var (vertices, triangles) = Generate();
        
        var mesh = new Mesh();
        mesh.name = Name;
        mesh.name = Name;
        mesh.vertices = vertices;
        
        //mesh.triangles = triangles;
        mesh.SetIndices(triangles, MeshTopology.Triangles, 0);

        //mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return PostCreate(mesh);

    }


}
