using UnityEngine;
using System.Collections;

public class PieceFactory : MonoBehaviour {

  // PREFABS
  [SerializeField]
  private GameObject piecePrefab;
  [SerializeField]
  private GameObject cubePrefab;

  // CONSTANTS
  int[][][] pieces = new int[][][] {
    // Piece I
    new int[][] { new int[] {0, 0, 0, 0}, new int[] {1, 1, 1, 1} },
    // Piece O
    new int[][] { new int[] {1, 1, 0, 0}, new int[] {1, 1, 0, 0} },
    // Piece J
    new int[][] { new int[] {1, 1, 1, 0}, new int[] {1, 0, 0, 0} },
    // Piece L
    new int[][] { new int[] {1, 1, 1, 0}, new int[] {0, 0, 1, 0} },
    // Piece S
    new int[][] { new int[] {0, 1, 1, 0}, new int[] {1, 1, 0, 0} },
    // Piece Z
    new int[][] { new int[] {1, 1, 0, 0}, new int[] {0, 1, 1, 0} },
    // Piece T
    new int[][] { new int[] {1, 1, 1, 0}, new int[] {0, 1, 0, 0} }
  };

  // VARIABLES
  private GameObject piecePool;
  private GameObject cube;

  // PROPERTIES
  private static int RandomPieceIndex {
    get { return Random.Range(0, GlobalConstants.PieceTypeAmount); }
  }

  private static Color RandomColor { 
    get { return new Color(Random.value, Random.value, Random.value, 1.0f); }
  }

  // MONO BEHAVIOUR
  void Awake() {
    piecePool = new GameObject("PiecePool");
  }

  // PUBLIC BEHAVIOUR
  public GameObject CreatePiece() {
    return CreatePiece(RandomPieceIndex);
  }

  public GameObject CreatePiece(int index) {
    GameObject piece = Instantiate(piecePrefab) as GameObject;
    piece.name = "Piece" + index;
    piece.transform.SetParent(piecePool.transform);
    piece = FormPiece(piece, index);
    piece = ColorPiece(piece);

    return piece;
  }

  // PRIVATE BEHAVIOUR
  private GameObject FormPiece(GameObject piece, int index) {
    for (int i = 0; i < pieces[index].Length; i++) {
      for (int j = 0; j < pieces[index][i].Length; j++) {
        if (pieces[index][i][j] == 1) { 
          cube = GameObject.Instantiate(cubePrefab);
          cube.transform.Translate(j, i, 0);
          cube.transform.parent = piece.transform;
        }
      }
    }
    piece.transform.position = GlobalConstants.SpawningPosition;
    return piece;
  }

  private GameObject ColorPiece(GameObject piece) {
    Color randomColor = RandomColor;
    foreach (Transform trans in piece.transform) {
      trans.GetComponent<Renderer>().material.color = randomColor;
    }
    return piece;
  }

}
