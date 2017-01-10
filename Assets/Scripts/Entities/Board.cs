using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

  // VARIABLES
  public static Transform[,] boardGrid = new Transform[10, 20];

  // PUBLIC BEHAVIOUR
  public void FillBoardWithPiece(Transform piece) {
    foreach (Transform cube in piece) {
      Debug.Log("Cubo a incluir: " + cube.position.x.ToString() + cube.position.y);
      FillBoardWithCube(cube);
    }
  }

  public static void FillBoardWithCube(Transform cube) {
    boardGrid[(int)cube.position.x, (int)cube.position.y] = cube;
  }

  public static bool IsPositionEmpty(Vector3 position) {
    return boardGrid[(int)position.x, (int)position.y] == null ? true : false;
  }

  public static void DebugBoard() {
    for (int i = 0; i < 10; i++) {
      for (int j = 0; j < 20; j++) {
        if (boardGrid[i, j] != null) {
          Debug.Log("Cubo: " + i.ToString() + j.ToString());
          Debug.Log(boardGrid[i, j]);
        }
      }
    }
  }

}
