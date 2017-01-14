using UnityEngine;
using System.Collections;

public class GlobalConstants {

  // BOARD
  public const int BoardWidth = 10;
  public const int BoardHeight = 20;

  public static Vector3 SpawningPosition {
    get { return new Vector3(BoardWidth / 2 - 2, BoardHeight - 2, 0); }
  }

  // PIECES
  public static int PieceTypeAmount = 7;

  public static int InitialPooledPiecesAmount = 3;

  // STYLES
  public static Color RandomColor { 
    get { return new Color(Random.value, Random.value, Random.value, 1.0f); }
  }

  // PHYSICS
  public static int PieceMovementsSpeed = 1;
  public static float GravitySpeed = .3f;

}

// POSITIONS
public enum PositionStates {
  Empty,
  Out,
  Full
}