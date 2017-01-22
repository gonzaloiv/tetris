using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

  // VARIABLES
  private static Transform[,] boardGrid = new Transform[10, 20];

  // PUBLIC BEHAVIOUR
  public static bool IsPositionEmpty(Vector3 position) {
    return boardGrid[(int) position.x, (int) position.y] == null ? true : false;
  }
   
  public void FillBoardWithPiece(Transform piece) {
    foreach (Transform cube in piece) {
      FillBoardWithCube(cube);
    }       
    UpdateGrid(); 
  }

  public void FillBoardWithCube(Transform cube) {
    cube.rotation = Quaternion.identity;
    boardGrid[(int)cube.position.x, (int)cube.position.y] = cube;
  }

  public void UpdateGrid() {
    for (int row = 0; row < Config.BoardHeight; row++) {
      if (IsRowFull(row)) {
        ResetRow(row);
        MoveHigherCubesDown(row);
        UpdateGrid();
      }
    }   
  }

  public void ResetGrid() { 
    for (int row = 0; row < Config.BoardHeight; row++) { 
      ResetRow(row); 
    }
  }
 
  // PRIVATE BEHAVIOUR
  private bool IsRowFull(int row) {
    for (int col = 0; col < Config.BoardWidth; col++) {
      if (boardGrid[col, row] == null) {
        return false;
      }
    }
    return true;
  }

  private void ResetRow(int row) {
    for (int col = 0; col < Config.BoardWidth; col++) {
      if (boardGrid[col, row] != null) {
        Destroy(boardGrid[col, row].gameObject);
        boardGrid[col, row] = null;
      }
    }
  }

  private void MoveHigherCubesDown(int fullRow) {
    for (int row = fullRow + 1; row < Config.BoardHeight; row++) {
      for (int col = 0; col < Config.BoardWidth; col++) {
        if (boardGrid[col, row] != null) {
          boardGrid[col, row].Translate(new Vector3(0, -Config.PieceMovementsSpeed, 0));
          boardGrid[col, row - 1] = boardGrid[col, row];
          boardGrid[col, row] = null;        
        }
      }
    }
  }

}
