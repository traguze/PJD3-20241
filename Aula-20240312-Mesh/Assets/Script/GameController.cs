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

        var cubeParams = new CubeMeshParams()
        {
            //Width = 2,
            //Height = 3,
            //Length = 0.5f,
            Pivot = new Vector3(0.5f,0.5f,0.5f),
        };

        mf.sharedMesh = mg.Create(cubeParams);
        mr.sharedMaterial = material;

        go.AddComponent<MeshNormalDraw>();
    }
}

