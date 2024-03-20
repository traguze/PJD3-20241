using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MGQuad : MeshGen<MeshParams, MeshGenerateReturn>
{

    protected override MeshGenerateReturn Generate()
    {
        Name = "MG_Quad";

        float Size = 1.0f;
        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (Pivot.x + 0.0f, Pivot.y + 0.0f, Pivot.z + 0.0f), // 0
            new Vector3 (Pivot.x + Size, Pivot.y + 0.0f, Pivot.z + 0.0f), // 1
            new Vector3 (Pivot.x + Size, Pivot.y + Size, Pivot.z + 0.0f), // 2
            new Vector3 (Pivot.x + 0.0f, Pivot.y + Size, Pivot.z + 0.0f), // 3
        };

        int[] triangles = new int[]
        {
            2,1,0,
            0,3,2,
        };

        return new MeshGenerateReturn()
        {
            vertices = vertices,
            triangles = triangles,
        };
    }
}
