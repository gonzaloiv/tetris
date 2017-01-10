using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePooler : MonoBehaviour {
  
  // VARIABLES
  private List<GameObject> pooledPieces = new List<GameObject>();
  private List<int> pooledPiecesIndexes = new List<int>();
  private PieceFactory pieceFactory;
  private GameObject piece;

  // MONO BEHAVIOUR
  void Awake() {
    pieceFactory = GetComponent<PieceFactory>();
    for (int i = 0; i < GlobalConstants.InitialPooledPiecesAmount; i++) {
      for (int j = 0; j < GlobalConstants.PieceTypeAmount; j++) {
        // TODO: Que no se creen de manera aleatoria sino mediante algún algoritmo que haga unas piezas más regulares que otras
        piece = pieceFactory.CreatePiece(j) as GameObject;
        piece.SetActive(false);
        pooledPieces.Add(piece);
      }
    }
  }

  // PUBLIC BEHAVIOUR
  public GameObject GetRandomPiece() {
    int randomIndex;
    while (pooledPiecesIndexes.Count < pooledPieces.Count) {
      do { randomIndex = Random.Range(0, GlobalConstants.PieceTypeAmount); } 
      while (!pooledPiecesIndexes.Contains(randomIndex));

      if (!pooledPieces[i].activeInHierarchy) 
        pooledPiecesIndexes.Clear();
        return pooledPieces[i];

      pooledPiecesIndexes.Add(randomIndex); 
    }  

    piece = pieceFactory.CreatePiece() as GameObject;
    piece.SetActive(false);
    pooledPieces.Add(piece);  

    return piece;
  } 

}