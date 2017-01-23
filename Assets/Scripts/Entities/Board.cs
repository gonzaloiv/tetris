using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {

  // VARIABLES
  private static Transform[,] boardGrid;

  // CONSTRUCTORS
  public Board(int boardWidth, int boardHeight) {
    boardGrid = new Transform[boardWidth, boardHeight];
  }

  // PUBLIC BEHAVIOUR
  public static bool IsPositionEmpty(Vector3 position) {
    return boardGrid[(int) position.x, (int) position.y] == null ? true : false;
  }
  
  public void AddPiece(GameObject piece) {
    foreach (Transform cube in piece.transform)
      AddCube(cube);
    UpdateGrid();
  }

  private void AddCube(Transform cube) {
    cube.rotation = Quaternion.identity;
    boardGrid[(int)cube.position.x, (int)cube.position.y] = cube;
  }

  private void UpdateGrid(int initialRow = 0) {
    for (int row = initialRow; row < Config.BoardHeight; row++) {
      if (IsRowFull(row)) {
        ResetRow(row);
        MoveHigherCubesDown(row);
        UpdateGrid(row++);
      }
    }   
  }

  public void Reset() {
    for (int row = 0; row < Config.BoardHeight; row++)
      ResetRow(row); 
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
        boardGrid[col, row].gameObject.SetActive(false);
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
