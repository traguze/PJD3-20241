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

        var mg = new MGQuad();

        mf.sharedMesh = mg.Create();
        mr.sharedMaterial = material;

    }
}

