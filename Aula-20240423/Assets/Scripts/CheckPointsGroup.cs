using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsGroup : MonoBehaviour
{
    static protected Dictionary<string, List<Vector3>> CheckPointGroups = new Dictionary<string, List<Vector3>>();

    protected Transform tf;

    public string GroupName = "npc1";

    public List<Vector3> Points = new List<Vector3>();
    private void Awake()
    {
        tf = GetComponent<Transform>();

        for (int i = 0; i < tf.childCount; i++)
        {
            Points.Add(tf.GetChild(i).position);
        }

        CheckPointGroups.Add(GroupName, Points);
    }

    static public List<Vector3> GetCheckPointsByName(string name)
    {
        return CheckPointGroups[name];
    }
}
