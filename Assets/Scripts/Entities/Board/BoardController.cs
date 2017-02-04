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
    EventManager.StartListening<PieceHitEvent>(FillBoardWithPiece);
    EventManager.StartListening<EndGameEvent>(ResetBoard);
  }

  void OnDisable() {
    EventManager.StopListening<PieceHitEvent>(FillBoardWithPiece);
    EventManager.StartListening<EndGameEvent>(ResetBoard);
  }

  // ACTIONS
  private void FillBoardWithPiece(PieceHitEvent pieceHitEvent) {
    board.AddPiece(pieceHitEvent.piece);
  }
  
  private void ResetBoard(EndGameEvent endGameEvent) { 
    board.Reset();
  }

}
