using System.Collections.Generic;
using UnityEngine;

static public class Extensions {
  public static T RandomItem<T>(this List<T> list) {
    var index = Random.Range(0, list.Count);
    return list[index];
  }
}