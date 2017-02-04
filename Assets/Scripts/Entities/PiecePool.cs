using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePool : MonoBehaviour {
  
  // VARIABLES
  private List<GameObject> pooledPieces = new List<GameObject>();
  private PieceFactory pieceFactory;
  private GameObject piecePool;

  // MONO BEHAVIOUR
  void Awake() {
    piecePool = new GameObject("PiecePool");
    pieceFactory = GetComponent<PieceFactory>();
    InitializePool();
  }

  // PUBLIC BEHAVIOUR
  public GameObject GetPiece() {
    GameObject piece = GetRandomInactivePooledPiece();
    if (piece == null) {
      piece = pieceFactory.CreatePiece() as GameObject;
      piece.transform.SetParent(piecePool.transform);
      pooledPieces.Add(piece);
    }
    piece.SetActive(true);

    return piece;
  }

  // PRIVATE BEHAVIOUR
  private void InitializePool() {
    for (int i = 0; i < Config.InitialPooledPiecesAmount; i++) {
      for (int j = 0; j < Config.PieceTypeAmount; j++) {
        GameObject piece = pieceFactory.CreatePiece(j) as GameObject;
        piece.transform.SetParent(piecePool.transform);
        pooledPieces.Add(piece);
      }
    }
  }

  private GameObject GetRandomInactivePooledPiece() {
    int randomIndex;
    List<int> pooledPiecesIndexes = new List<int>();

    while (pooledPiecesIndexes.Count < pooledPieces.Count) {
      do {
        randomIndex = Random.Range(0, Config.PieceTypeAmount);
      } while (pooledPiecesIndexes.Contains(randomIndex));

      if (!pooledPieces[randomIndex].activeInHierarchy)
        return pooledPieces[randomIndex];

      pooledPiecesIndexes.Add(randomIndex); 
    }  

    return null;
  }

}