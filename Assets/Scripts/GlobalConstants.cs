using UnityEngine;
using System.Collections;

public class GlobalConstants {

  public static int PieceTypeAmount = 7;   
  public const int BoardWidth = 10;
  public const int BoardHeight = 20;

  public static int InitialPooledPiecesAmount {
    get { return PieceTypeAmount * 2; }
  }

  public static Vector3 BoardCenter {
    get { return new Vector3(GlobalConstants.BoardWidth / 2, GlobalConstants.BoardHeight, 0); }
  } 

}

