using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

  // PREFABS
  public GameObject boardPrefab;

  // VARIABLES
  private PieceFactory pieceFactory;
  private GameObject board;
  private GameObject activePiece;

  // MONO BEHAVIOUR
  void Awake() {
    pieceFactory = GetComponent<PieceFactory>();
    board = Instantiate(boardPrefab) as GameObject;
    board.name = "Board"; 

    SpawnPiece();
    StartCoroutine(SimulateGravity());
  }

  void OnEnable() {
    EventManager.StartListening("SpawnPiece", SpawnPiece);
    EventManager.StartListening("FillBoardWithPiece", FillBoardWithPiece);
  }

  void OnDisable() {
    EventManager.StopListening("SpawnPiece", SpawnPiece);
    EventManager.StartListening("FillBoardWithPiece", FillBoardWithPiece);
  }

  // ACTIONS
  private void SpawnPiece() {
    EventManager.TriggerEvent("MoveDown");

    activePiece = pieceFactory.CreatePiece() as GameObject;
  }

  private void FillBoardWithPiece () {
    board.GetComponent<Board>().FillBoardWithPiece(activePiece.transform);
  }

  // PRIVATE BEHAVIOUR
  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent("MoveDown");
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }

}