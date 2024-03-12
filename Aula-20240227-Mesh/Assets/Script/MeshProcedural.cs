using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshProcedural : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public float Size = 1.0f;
    public Vector3 Pivot = Vector3.zero;

    private float currentSize = 1.0f;
    private Vector3 currentPivot = Vector3.zero;

    private bool isDirty;

    private void Awake()
    {
        GenerateMesh();

        currentSize = Size;
        currentPivot = Pivot;
    }

    void GenerateMesh()
    {
        var go = new GameObject("Mesh");
        var mf = go.AddComponent<MeshFilter>();
        var mr = go.AddComponent<MeshRenderer>();

        mesh = new Mesh();
        mesh.name = "Quad_Procedural";

        

        mf.sharedMesh = mesh;

        mr.sharedMaterial = material;

        UpdateMesh();
    }

    void UpdateMesh()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (Pivot.x + 0.0f, Pivot.y + 0.0f, Pivot.z + 0.0f), // 0
            new Vector3 (Pivot.x + Size, Pivot.y + 0.0f, Pivot.z + 0.0f), // 1
            new Vector3 (Pivot.x + Size, Pivot.y + Size, Pivot.z + 0.0f), // 2
            new Vector3 (Pivot.x + 0.0f, Pivot.y + Size, Pivot.z + 0.0f), // 3
        };

        mesh.vertices = vertices;

        int[] triangles = new int[]
        {
            2,1,0,
            0,3,2,
        };

        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        //mesh.RecalculateNormals();
    }

    private void Update()
    {
        if(Size != currentSize)
        {
            isDirty = true;
        }

        if (Size != currentSize)
        {
            isDirty = true;
        }


        if(isDirty)
        {
            currentSize = Size;
            currentPivot = Pivot;
            UpdateMesh();
        }
    }
}
