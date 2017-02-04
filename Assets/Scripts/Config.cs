using UnityEngine;
using System.Collections;

public class Config {

  // BOARD
  public const int BoardWidth = 10;
  public const int BoardHeight = 20;

  public static Vector3 SpawningPosition {
    get { return new Vector3(BoardWidth / 2 - 2, BoardHeight - 2, 0); }
  }

  // PIECES
  public static int PieceTypeAmount = 7;
  public static int InitialPooledPiecesAmount = 14;
  public static int InitialPooledCubesAmount = 32;

  // STYLES
  public static Color RandomColor { 
    get { return new Color(Random.value, Random.value, Random.value, 1.0f); }
  }

  // PHYSICS
  public static int PieceMovementsSpeed = 1;
  public static float GravitySpeed = .4f;
  public static int PieceRotationAngle = 90;

}

public enum PositionStates {
  Empty,
  Out,
  Full
}