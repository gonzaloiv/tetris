using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  
  // PREFABS
  private PiecePooler piecePooler;
  private BoardManager boardManager;

  // MONO BEHAVIOUR
  void Awake() {
    piecePooler = GetComponent<PiecePooler>();
    boardManager = GetComponent<BoardManager>();

    // test de creación de piezas
    StartCoroutine(NextPiece());
  }

  void Update() {
   
  }

  // PRIVATE BEHAVIOUR
  private IEnumerator NextPiece() {
    for (int i = 0; i < GlobalConstants.PieceTypeAmount; i++) {
      WaitForSeconds delay = new WaitForSeconds(1);
      yield return delay;
      GameObject piece;
      piece = piecePooler.GetPiece();
      if (piece != null) {
        piece.transform.localPosition = GlobalConstants.BoardCenter;
        piece.SetActive(true);
      }
    } 
  }

}