using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshNormalDraw : MonoBehaviour
{
    protected Mesh mesh;
    protected Transform tf;
    private void Awake()
    {
        tf = GetComponent<Transform>();
        mesh = GetComponent<MeshFilter>().sharedMesh;

        Debug.Log($"Mesh {mesh.name} vertices:{mesh.vertexCount} normals:{mesh.normals.Length}");

    }

    private void Update()
    {
        var p = tf.position;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            var v = mesh.vertices[i];
            var n = mesh.normals[i];
            Debug.DrawRay(p+v, n, Color.red);
        }
    }
}
