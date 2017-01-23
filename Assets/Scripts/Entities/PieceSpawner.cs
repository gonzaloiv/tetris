using UnityEngine;
using System.Collections;

public class PieceSpawner : Singleton<PieceSpawner> {

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

  // PREFABS
  [SerializeField] private GameObject piecePrefab;
  [SerializeField] private GameObject cubePrefab;

  // VARIABLES
  private GameObject cube;

  // MONO BEHAVIOUR
  void Awake() {
    Pooler.CreateGameObjectPool(piecePrefab, Config.InitialPooledPiecesAmount, transform);
    Pooler.CreateGameObjectPool(cubePrefab, Config.InitialPooledCubesAmount, transform);
  }

  // PUBLIC BEHAVIOUR
  public GameObject NextPiece() {
    return NextPiece(RandomPieceIndex);
  }

  public GameObject NextPiece(int index) {
    GameObject piece =  Pooler.GetPooledGameObject("PiecePool");
    piece.transform.position = Config.SpawningPosition;
    piece = FormPiece(piece, index);
    piece = ColorPiece(piece);
    piece.SetActive(true);

    return piece;
  }

  // PRIVATE BEHAVIOUR
  private GameObject FormPiece(GameObject piece, int index) {
    for (int i = 0; i < pieces[index].Length; i++) {
      for (int j = 0; j < pieces[index][i].Length; j++) {
        if (pieces[index][i][j] == 1) { 
          cube = Pooler.GetPooledGameObject("CubePool");
          cube.transform.position = new Vector3(j, i, 0);
          cube.SetActive(true);
          cube.transform.parent = piece.transform;
        }
      }
    }
    return piece;
  }

  private GameObject ColorPiece(GameObject piece) {
    Color randomColor = RandomColor;
    foreach (Transform trans in piece.transform)
      trans.GetComponent<Renderer>().material.color = randomColor;

    return piece;
  }

  private static int RandomPieceIndex {
    get { return Random.Range(0, Config.PieceTypeAmount); }
  }

  private static Color RandomColor { 
    get { return new Color(Random.value, Random.value, Random.value, 1.0f); }
  }

}
