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

public class MGCube : MeshGen<CubeMeshParams>
{
    protected override (Vector3[], int[]) Generate()
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
            
            //Vector3.zero.Y( hh), //  0, Y+
            //Vector3.zero.Y( hh), //  0, Y+
            //Vector3.zero.Y( hh), //  0, Y+
            //Vector3.zero.Y( hh), //  0, Y+

            //Vector3.zero.Y(-hh), //  0, Y-
            //Vector3.zero.Y(-hh), //  0, Y-
            //Vector3.zero.Y(-hh), //  0, Y-
            //Vector3.zero.Y(-hh), //  0, Y-

            //Vector3.zero.Z( hl), //  0, Z+
            //Vector3.zero.Z( hl), //  0, Z+
            //Vector3.zero.Z( hl), //  0, Z+
            //Vector3.zero.Z( hl), //  0, Z+

            //Vector3.zero.Z(-hl), //  0, Z-
            //Vector3.zero.Z(-hl), //  0, Z-
            //Vector3.zero.Z(-hl), //  0, Z-
            //Vector3.zero.Z(-hl), //  0, Z-
        };

        Debug.Log($"{Pivot} {vertices[0]}");
        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] -= Pivot;
        }

        int[] triangles = new int[] {
            0,1,2, // X+
            2,3,0, // X+
            4,7,6, // X-
            6,5,4, // X-
            1,0,4, // Y+
            1,4,5, // Y+
            2,6,3, // Y-
            3,6,7, // Y-
            2,5,6, // Z+
            5,2,1, // Z+
            0,3,4, // Z-
            7,4,3, // Z-
        };

        return (vertices.ToArray(), triangles);

    }

    public override Mesh PostCreate(Mesh m)
    {
        m.RecalculateNormals();
        return m;
    }
}
