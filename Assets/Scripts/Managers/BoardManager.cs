using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

  // PREFABS
  public GameObject boardPrefab;

  // VARIABLES
  private PieceFactory pieceFactory;
  private Board board;
  private GameObject activePiece;

  // MONO BEHAVIOUR
  void Awake() {
    pieceFactory = GetComponent<PieceFactory>();
    board = Instantiate(boardPrefab).GetComponent<Board>();

    SpawnPiece();
    StartCoroutine(SimulateGravity());
  }

  void OnEnable() {
    EventManager.StartListening("SpawnPiece", SpawnPiece);
    EventManager.StartListening("FillBoardWithPiece", FillBoardWithPiece);
    EventManager.StartListening("Restart", Restart);
  }

  void OnDisable() {
    EventManager.StopListening("SpawnPiece", SpawnPiece);
    EventManager.StartListening("FillBoardWithPiece", FillBoardWithPiece);
    EventManager.StartListening("Restart", Restart);
  }

  // ACTIONS
  private void SpawnPiece() {
    activePiece = pieceFactory.CreatePiece() as GameObject;
  }

  private void FillBoardWithPiece () {
    board.FillBoardWithPiece(activePiece.transform);
    board.UpdateBoard();
  }

  private void Restart() {
    // Aquí se modificaría también lo relacionado con la partida (puntos, GUI...)
    board.ResetGrid();
  }

  // PRIVATE BEHAVIOUR
  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent("MoveDown");
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }

}