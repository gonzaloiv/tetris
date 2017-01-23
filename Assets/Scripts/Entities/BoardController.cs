using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

  // VARIABLES
  private Board board;

  // MONO BEHAVOUR
  void Start() {
    board = new Board(Config.BoardWidth, Config.BoardHeight);
  }

  void OnEnable() {
    EventManager.StartListening<PieceHitEvent>(OnPieceHitEvent);
    EventManager.StartListening<EndGameEvent>(OnEndGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PieceHitEvent>(OnPieceHitEvent);
    EventManager.StartListening<EndGameEvent>(OnEndGameEvent);
  }

  // ACTIONS
  private void OnPieceHitEvent(PieceHitEvent pieceHitEvent) {
    board.AddPiece(pieceHitEvent.piece);
  }
  
  private void OnEndGameEvent(EndGameEvent endGameEvent) { 
    board.Reset();
  }

}
