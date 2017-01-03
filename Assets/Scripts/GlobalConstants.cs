using UnityEngine;
using System.Collections;

public class GlobalConstants {

  // BOARD
  public const int BoardWidth = 10;
  public const int BoardHeight = 20;

  public static Vector3 BoardCenter {
    get { return new Vector3(-1f, GlobalConstants.BoardHeight, 0); }
  }

  // PIECES
  public static int PieceTypeAmount = 7;

  public static int InitialPooledPiecesAmount {
    get { return PieceTypeAmount * 3; }
  }

  // PHYSICS
  public static int PieceMovementsSpeed = 1;

  // TESTING CONSTANTS
  // public static Vector3 BoardCenter {
  //   get { return new Vector3(Random.Range(-GlobalConstants.BoardWidth / 2, GlobalConstants.BoardWidth / 2 - 2), GlobalConstants.BoardHeight, 0); }
  // }

}