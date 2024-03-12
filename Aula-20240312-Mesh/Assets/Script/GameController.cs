using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        CreateComponent();
    }

    void CreateComponent()
    {
        var go = new GameObject("Mesh");
        var mf = go.AddComponent<MeshFilter>();
        var mr = go.AddComponent<MeshRenderer>();

        var material = new Material(Shader.Find("Standard"));

        var mg = new MGCube();

        mf.sharedMesh = mg.Create(new CubeMeshParams());
        mr.sharedMaterial = material;


        Vector3 v = Vector3.zero;
        Debug.Log(v);
        
        v = Vector3.zero.X(1);
        Debug.Log(v);

        v = Vector3.zero.Y(1).X(2);
        Debug.Log(v);

        v = Vector3.zero.Z(1).Y(3).X(10);
        Debug.Log(v);

    }
}

