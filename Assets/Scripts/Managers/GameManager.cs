using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  // PREFABS
  public GameObject boardPrefab;
  public GameObject restartScreenPrefab;

  // VARIABLES
  private PieceFactory pieceFactory;
  private Board board;
  private GameObject activePiece;
  private GameObject restartScreen;

  // MONO BEHAVIOUR
  void Awake() {
    pieceFactory = GetComponent<PieceFactory>();
    board = Instantiate(boardPrefab).GetComponent<Board>();

    StartCoroutine(SimulateGravity());
    SpawnPiece();
  }

  void OnEnable() {
    EventManager.StartListening("SpawnPiece", SpawnPiece);
    EventManager.StartListening("FillBoardWithPiece", FillBoardWithPiece);
    EventManager.StartListening("EndGame", EndGame);
    EventManager.StartListening("RestartGame", RestartGame);
  }

  void OnDisable() {
    EventManager.StopListening("SpawnPiece", SpawnPiece);
    EventManager.StopListening("FillBoardWithPiece", FillBoardWithPiece);
    EventManager.StopListening("EndGame", EndGame);
    EventManager.StopListening("RestartGame", RestartGame);
  }

  // ACTIONS
  private void SpawnPiece() {
    activePiece = pieceFactory.CreatePiece() as GameObject;
  }

  private void FillBoardWithPiece () {
    board.FillBoardWithPiece(activePiece.transform);
  }

  private void EndGame() {
    restartScreen = Instantiate(restartScreenPrefab) as GameObject;
  }

  private void RestartGame() {
    DestroyAllPieces();    
    Destroy(restartScreen);
    board.ResetGrid();
    SpawnPiece();
  }

  // PRIVATE BEHAVIOUR
  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent("MoveDown");
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }

  private void DestroyAllPieces() {
    GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gameObject in allObjects) {
      if(gameObject.activeInHierarchy && gameObject.name.Contains("Piece"))
        Destroy(gameObject);
    }
  }

}