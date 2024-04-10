using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVertexColor : MonoBehaviour
{
    protected Mesh mesh;

    private void Awake()
    {
        mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;

        Color32[] colors = new Color32[mesh.vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color32(
                (byte)Random.Range(0,255),
                (byte)Random.Range(0, 255),
                (byte)Random.Range(0, 255),
                (byte)Random.Range(0, 255)
            );
        }
        mesh.colors32 = colors;
    }
}
