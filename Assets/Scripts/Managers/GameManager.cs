using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  // PREFABS
  public GameObject boardPrefab;
  public GameObject restartScreenPrefab;

  // VARIABLES
  private PieceFactory pieceFactory;
  private GameObject restartScreen;

  // MONO BEHAVIOUR
  void Awake() {
    Instantiate(boardPrefab);
    EventManager.TriggerEvent("SpawnPiece");
    StartCoroutine(SimulateGravity());
  }

  void OnEnable() {
    EventManager.StartListening("EndGame", EndGame);
    EventManager.StartListening("RestartGame", RestartGame);
  }

  void OnDisable() {
    EventManager.StopListening("EndGame", EndGame);
    EventManager.StopListening("RestartGame", RestartGame);
  }

  // ACTIONS
  private void EndGame() {
    StopCoroutine(SimulateGravity());
    restartScreen = Instantiate(restartScreenPrefab) as GameObject;
  }

  private void RestartGame() {
    DestroyGamePieces();    
    Destroy(restartScreen);
    // TODO: implementar el el tablero en eventos
    Board.ResetGrid();
    EventManager.TriggerEvent("SpawnPiece");
  }

  // PRIVATE BEHAVIOUR

  private void DestroyGamePieces() {
    GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gameObject in allObjects) {
      if(gameObject.activeInHierarchy && gameObject.name.Contains("Piece"))
        Destroy(gameObject);
    }
  }

  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent("MoveDown");
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }

}