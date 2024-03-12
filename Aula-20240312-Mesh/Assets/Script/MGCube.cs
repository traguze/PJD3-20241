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
        float hw = Params.Width * 0.5f;
        float hh = Params.Height * 0.5f;
        float hl = Params.Length * 0.5f;
        Vector3[] vertices = new Vector3[] {
            Vector3.zero.X( hw).Y( hh).Z(-hl), //  0, X+
            Vector3.zero.X( hw).Y( hh).Z( hl), //  1, X+
            Vector3.zero.X( hw).Y(-hh).Z( hl), //  2, X+
            Vector3.zero.X( hw).Y(-hh).Z(-hl), //  3, X+

            Vector3.zero.X(-hw).Y( hh).Z(-hl), //  4, X-
            Vector3.zero.X(-hw).Y( hh).Z( hl), //  5, X-
            Vector3.zero.X(-hw).Y(-hh).Z( hl), //  6, X-
            Vector3.zero.X(-hw).Y(-hh).Z(-hl), //  7, X-
            
            Vector3.zero.Y( hh), //  0, Y+
            Vector3.zero.Y( hh), //  0, Y+
            Vector3.zero.Y( hh), //  0, Y+
            Vector3.zero.Y( hh), //  0, Y+

            Vector3.zero.Y(-hh), //  0, Y-
            Vector3.zero.Y(-hh), //  0, Y-
            Vector3.zero.Y(-hh), //  0, Y-
            Vector3.zero.Y(-hh), //  0, Y-

            Vector3.zero.Z( hl), //  0, Z+
            Vector3.zero.Z( hl), //  0, Z+
            Vector3.zero.Z( hl), //  0, Z+
            Vector3.zero.Z( hl), //  0, Z+

            Vector3.zero.Z(-hl), //  0, Z-
            Vector3.zero.Z(-hl), //  0, Z-
            Vector3.zero.Z(-hl), //  0, Z-
            Vector3.zero.Z(-hl), //  0, Z-

        };

        int[] triangles = new int[] {
            0,1,2, // X+
            2,3,0,// X+


        };

        return (vertices, triangles);

    }
}
