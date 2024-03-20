using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CubeMeshParams : MeshParams
{
    public float Width = 1f;
    public float Height = 1f;
    public float Length = 1f;
}



public class MGCube : MeshGen<CubeMeshParams, MeshGenerateVectorTriangleNormal>
{
    protected override MeshGenerateVectorTriangleNormal Generate()
    {

        Name = "MG_Cube";

        float hw = Params.Width * 0.5f;
        float hh = Params.Height * 0.5f;
        float hl = Params.Length * 0.5f;
        List<Vector3> vertices = new List<Vector3> {
            Vector3.zero.X( hw).Y( hh).Z(-hl), //  0, X+
            Vector3.zero.X( hw).Y( hh).Z( hl), //  1, X+
            Vector3.zero.X( hw).Y(-hh).Z( hl), //  2, X+
            Vector3.zero.X( hw).Y(-hh).Z(-hl), //  3, X+

            Vector3.zero.X(-hw).Y( hh).Z(-hl), //  4, X-
            Vector3.zero.X(-hw).Y( hh).Z( hl), //  5, X-
            Vector3.zero.X(-hw).Y(-hh).Z( hl), //  6, X-
            Vector3.zero.X(-hw).Y(-hh).Z(-hl), //  7, X-
            
            Vector3.zero.X( hw).Y( hh).Z( hl), //  8, Y+
            Vector3.zero.X( hw).Y( hh).Z(-hl), //  9, Y+
            Vector3.zero.X(-hw).Y( hh).Z(-hl), // 10, Y+
            Vector3.zero.X(-hw).Y( hh).Z( hl), // 11, Y+

            Vector3.zero.X( hw).Y(-hh).Z( hl), // 12, Y-
            Vector3.zero.X( hw).Y(-hh).Z(-hl), // 13, Y-
            Vector3.zero.X(-hw).Y(-hh).Z(-hl), // 14, Y-
            Vector3.zero.X(-hw).Y(-hh).Z( hl), // 15, Y-

            Vector3.zero.X( hw).Y( hh).Z( hl), // 16, Z+
            Vector3.zero.X( hw).Y(-hh).Z( hl), // 17, Z+
            Vector3.zero.X(-hw).Y(-hh).Z( hl), // 18, Z+
            Vector3.zero.X(-hw).Y( hh).Z( hl), // 19, Z+

            Vector3.zero.X( hw).Y( hh).Z(-hl), // 20, Z-
            Vector3.zero.X( hw).Y(-hh).Z(-hl), // 21, Z-
            Vector3.zero.X(-hw).Y(-hh).Z(-hl), // 22, Z-
            Vector3.zero.X(-hw).Y( hh).Z(-hl), // 23, Z-
        };

        Debug.Log($"{Pivot} {vertices[0]}");
        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] -= Pivot;
        }
        
        Vector3[] normals = new Vector3[] {
            Vector3.right,
            Vector3.right,
            Vector3.right,
            Vector3.right,
            Vector3.left,
            Vector3.left,
            Vector3.left,
            Vector3.left,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.down,
            Vector3.down,
            Vector3.down,
            Vector3.down,
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.back,
            Vector3.back,
            Vector3.back,
            Vector3.back,
        };

        int[] triangles = new int[] {
            0,1,2, // X+
            2,3,0, // X+
            4,7,6, // X-
            6,5,4, // X-
            8,9,10, // Y+
            8,10,11, // Y+
            12,14,13, // Y-
            12,15,14, // Y-
            16,18,17, // Z+
            16,19,18, // Z+
            20,21,22, // Z-
            20,22,23, // Z-
        };


        return new MeshGenerateVectorTriangleNormal() {
            vertices = vertices.ToArray(),
            triangles = triangles,
            normals = normals,
        };
    }

    public override Mesh PostCreate(Mesh m)
    {
        //m.RecalculateNormals();
        return m;
    }
}
