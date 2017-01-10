using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

  // PREFABS
  public GameObject boardPrefab;

  // VARIABLES
  private PiecePooler piecePooler;
  private GameObject activePiece;
  private GameObject board;

  // MONO BEHAVIOUR
  void Awake() {
    piecePooler = GetComponent<PiecePooler>();
    board = Instantiate(boardPrefab) as GameObject;

    activePiece = new GameObject("ActivePiece");
    activePiece.transform.parent = gameObject.transform;

    // test de creación de piezas
    StartCoroutine(NextPiece());
  }
 
  // PRIVATE BEHAVIOUR
  private IEnumerator NextPiece() {
    for (int i = 0; i < GlobalConstants.PieceTypeAmount; i++) {
      Destroy(activePiece.GetComponent<PieceController>());
      Debug.Log(activePiece);
      Debug.Log(piecePooler);
      activePiece = piecePooler.GetRandomPiece() as GameObject;
      activePiece.SetActive(true);

      yield return new WaitForSeconds(2);
    }
  }

}