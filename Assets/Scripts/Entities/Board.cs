using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

  // VARIABLES
  private Transform[,] boardGrid = new Transform[10, 20];

  // PUBLIC BEHAVIOUR
  public void FillBoardWithPiece(Transform piece) {
    foreach(Transform cube in piece) {
      FillBoardWithCube(cube);
    }
  }

  public void FillBoardWithCube(Transform cube) {
    boardGrid[(int)cube.transform.position.x, (int)cube.transform.position.y] = cube;
  }

  public bool IsPositionEmpty(Vector3 position) {
    return boardGrid[(int)position.x, (int)position.y] is Transform ? true : false;
  }

}
