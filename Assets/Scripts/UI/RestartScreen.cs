using UnityEngine;
using System.Collections;

public class RestartScreen : MonoBehaviour {

  // PREFABS
  public GameObject hudPrefab;

  // VARIABLES
  private GameObject hud;
  private Transform restartText;

  // MONO BEHAVIOUR
	void Awake () {
	  hud = Instantiate(hudPrefab) as GameObject;
    restartText = hud.transform.Find("RestartText");
	}

  void OnEnable() {
    EventManager.StartListening("RestartGame", RestartGame);
  }

  void OnDisable() {
    EventManager.StartListening("RestartGame", RestartGame);
  }

  // PRIVATE BEHAVIOUR
  private void RestartGame() {
    
  }

}
