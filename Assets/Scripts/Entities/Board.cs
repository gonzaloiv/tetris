using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

  // VARIABLES
  private static Transform[,] boardGrid = new Transform[10, 20];

  // PUBLIC BEHAVIOUR
  public void FillBoardWithPiece(Transform piece) {
    foreach (Transform cube in piece) {
      FillBoardWithCube(cube);
    }
  }

  public void FillBoardWithCube(Transform cube) {
    boardGrid[(int)cube.position.x, (int)cube.position.y] = cube;
  }

  public static bool IsPositionEmpty(Vector3 position) {
    return boardGrid[(int)position.x, (int)position.y] == null ? true : false;
  }

  public void UpdateBoard() {
    for (int row = 0; row < GlobalConstants.BoardHeight; row++) {
      if (IsRowFull(row)) {
        ResetRow(row);
        UpdateBoard();
      }
    }   
  }

  public void ResetGrid() { 
    for (int i = 0; i < GlobalConstants.BoardHeight; i++) { 
      ResetRow(i); 
    }
  }
 
  // PRIVATE BEHAVIOUR
  private bool IsRowFull(int row) {
    for (int col = 0; col < GlobalConstants.BoardWidth; col++){
      if (boardGrid[col, row] == null)
        return false;
    }
    return true;
  }

  private void ResetRow(int row) {
    for (int col = 0; col < GlobalConstants.BoardWidth; col++){
      Destroy(boardGrid[col, row].gameObject);
      boardGrid[col, row] = null;
      Debug.Log("Queda en la fila: " + boardGrid[col, row]);
    }
    MoveHigherCubesDown(row);
  }

  private void MoveHigherCubesDown(int fullRow) {
    for (int row = fullRow + 1; row < GlobalConstants.BoardHeight; row++) {
      for (int col = 0; col < GlobalConstants.BoardWidth; col++) {
        if (boardGrid[col, row] != null) {
          boardGrid[col, row].Translate(new Vector3(0, -GlobalConstants.PieceMovementsSpeed, 0));
          boardGrid[col, row -1] = boardGrid[col, row];
          boardGrid[col, row] = null;        
        }
      }
    }
  }

}
