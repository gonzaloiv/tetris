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
    board = Instantiate(boardPrefab) as GameObject;
    piecePooler = GetComponent<PiecePooler>();
    activePiece = new GameObject("ActivePiece");
    activePiece.transform.parent = gameObject.transform;

    // test de creación de piezas
    // TODO: dependerá de las collisions con el grupo de piezas en el tablero
    StartCoroutine(NextPiece());
  }
 
  // PRIVATE BEHAVIOUR
  private IEnumerator NextPiece() {
    for (int i = 0; i < GlobalConstants.PieceTypeAmount; i++) {
      yield return new WaitForSeconds(2);

      // TODO: mejorar esto, porque genera el script de cada vez
      Destroy(activePiece.GetComponent<ActivePiece>());
      activePiece = piecePooler.GetPiece();
      activePiece.AddComponent<ActivePiece>();

  
      if (activePiece != null)
        activePiece.SetActive(true);
    }
  }

}