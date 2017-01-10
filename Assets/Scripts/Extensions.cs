using UnityEngine;
using System.Collections;

public class Extensions {

  public static Color GetTransformColor(Transform transform) {
    return transform.GetComponent<Renderer>().material.color;
  }

  public static GameObject SetTransformColor(GameObject gameObject, Color color) {
    gameObject.transform.GetComponent<Renderer>().material.color = color;
    return gameObject;
  }

}

