using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

  // VARIABLES
  private GameObject[,] cubeGrid = new GameObject[10, 20];
  private Transform ground;
  private Transform colLeft;
  private Transform colRight;

  // MONO BEHAVIOUR
  void Awake() {
    ground = gameObject.transform.Find("Ground");
    colLeft = gameObject.transform.Find("ColLeft");
    colRight = gameObject.transform.Find("ColRight");
  }

  // PUBLIC BEHAVIOUR


}
