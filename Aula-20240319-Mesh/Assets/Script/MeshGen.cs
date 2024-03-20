using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MeshGen<T0, T1> where T0 : MeshParams 
{
    public T0 Params { get; protected set; }

    public virtual Vector3 Pivot {  get; protected set; } = Vector3.zero;

    public string Name { get; protected set; }

    protected virtual T1 Generate()
    {
        T1 result = default(T1);
        return result;
    }

    public virtual Mesh PostCreate(Mesh m)
    {
        return m;
    }

    public Mesh Create(T0 meshParams)
    {
        Params = meshParams;
        Pivot = meshParams.Pivot;

        T1 result = Generate();
        
        ISetMeshData meshDataSetter = result as ISetMeshData;

        var mesh = new Mesh();
        mesh.name = Name;

        meshDataSetter.SetMeshData(ref mesh);
 
        //mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return PostCreate(mesh);

    }


}
