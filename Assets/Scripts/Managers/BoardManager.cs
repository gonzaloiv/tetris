using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

  // PREFABS
  public GameObject boardPrefab;

  // VARIABLES
  private PiecePooler piecePooler;
  private GameObject activePiece;

  // PROPERTIES
  private static Color RandomColor { 
    get { return new Color(Random.value, Random.value, Random.value, 1.0f); }
  }

  // MONO BEHAVIOUR
  void Awake() {
    Instantiate(boardPrefab);

    piecePooler = GetComponent<PiecePooler>();
    activePiece = new GameObject();

    // test de creación de piezas
    // TODO: dependerá de las collisions con el grupo de piezas en el tablero
    StartCoroutine(NextPiece());
  }
 
  // PRIVATE BEHAVIOUR
  private IEnumerator NextPiece() {
    for (int i = 0; i < GlobalConstants.PieceTypeAmount; i++) {
      yield return new WaitForSeconds(1);
      Destroy(activePiece.GetComponent<Piece>());
      activePiece = piecePooler.GetPiece();
      activePiece.AddComponent<Piece>();
      if (activePiece != null)
        SetPiece(activePiece);
    }
  }

  private void SetPiece(GameObject activePiece) {
    activePiece.transform.localPosition = GlobalConstants.BoardCenter;
    foreach (Transform trans in activePiece.transform) {
      trans.GetComponent<Renderer>().material.color = RandomColor;
    }
    activePiece.SetActive(true);
  }
 
}