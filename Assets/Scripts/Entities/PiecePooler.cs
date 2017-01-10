using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePooler : MonoBehaviour {
  
  // VARIABLES
  private List<GameObject> pooledPieces = new List<GameObject>();
  private PieceFactory pieceFactory;

  // MONO BEHAVIOUR
  void Awake() {
    pieceFactory = GetComponent<PieceFactory>();
    for (int i = 0; i < GlobalConstants.InitialPooledPiecesAmount; i++) {
      for (int j = 0; j < GlobalConstants.PieceTypeAmount; j++) {
        GameObject piece = pieceFactory.CreatePiece(j) as GameObject;
        piece.SetActive(false);
        pooledPieces.Add(piece);
      }
    }
  }

  // PUBLIC BEHAVIOUR
  public GameObject GetRandomPiece() {
    GameObject piece = GetRandomInactivePooledPiece();
    if (piece != null)
      return piece;

    piece = pieceFactory.CreatePiece() as GameObject;
    piece.SetActive(false);
    pooledPieces.Add(piece);  

    return piece;
  } 

  // PRIVATE BEHAVIOUR
  private GameObject GetRandomInactivePooledPiece() {
    int randomIndex;
    List<int> pooledPiecesIndexes = new List<int>();

    while (pooledPiecesIndexes.Count < pooledPieces.Count) {
      do {
        randomIndex = Random.Range(0, GlobalConstants.PieceTypeAmount);
      } while (pooledPiecesIndexes.Contains(randomIndex));

      if (!pooledPieces[randomIndex].activeInHierarchy)
        return pooledPieces[randomIndex];

      pooledPiecesIndexes.Add(randomIndex); 
    }  

    return null;
  }

}