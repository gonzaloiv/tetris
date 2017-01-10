using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePooler : MonoBehaviour {
  
  // VARIABLES
  private List<GameObject> pooledPieces = new List<GameObject>();
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
    Debug.Log(pooledPieces);
  }

  // PUBLIC BEHAVIOUR
  public GameObject GetRandomPiece() {
    Debug.Log(GetRandomAvailablePiece());
    piece = GetRandomAvailablePiece();
    if (piece != null)
      return piece;

    piece = pieceFactory.CreatePiece() as GameObject;
    piece.SetActive(false);
    pooledPieces.Add(piece);  

    return piece;
  } 

  // PRIVATE BEHAVIOUR
  private GameObject GetRandomAvailablePiece() {
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