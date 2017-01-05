using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

  // PREFAB
  public GameObject boardPrefab;

  // VARIABLES
  private PieceFactory pieceFactory;
  private GameObject activePiece;
  private GameObject board;

  // MONO BEHAVIOUR
  void Awake() {
    pieceFactory = GetComponent<PieceFactory>();
    board = Instantiate(boardPrefab) as GameObject;

    activePiece = new GameObject("ActivePiece");
    activePiece.transform.parent = gameObject.transform;

    // test de creación de piezas
    // TODO: dependerá de las collisions con el grupo de piezas en el tablero
    StartCoroutine(NextPiece());
  }

  // TODO: rutina de la partida
  void OnEnable() {}

  void OnDisable() {}

  // PRIVATE BEHAVIOUR
  private IEnumerator NextPiece() {
    for (int i = 0; i < GlobalConstants.PieceTypeAmount; i++) {
      Destroy(activePiece.GetComponent<PieceController>());
      activePiece = pieceFactory.CreatePiece(i) as GameObject;
      activePiece.transform.position = GlobalConstants.BoardCenter;

      yield return new WaitForSeconds(2);
    }
  }

}