using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

  // PREFABS
  public GameObject wallPrefab;
  public GameObject groundPrefab;

  // VARIABLES
  private GameObject wall;
  private GameObject ground;

  // MONO BEHAVIOUR
  void Awake() {
    wall = Instantiate(wallPrefab) as GameObject;
    ground = Instantiate(groundPrefab) as GameObject;
  }

  void Update() {

  }

}
