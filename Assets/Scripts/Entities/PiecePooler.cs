using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePooler : MonoBehaviour {
  
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

  void OnEnable() {
    EventManager.StartListening("SpawnPiece", SpawnPiece);
  }

  void OnDisable() {
    EventManager.StopListening("SpawnPiece", SpawnPiece);
  }

  // ACTIONS
  void SpawnPiece() {
    GameObject piece = GetRandomInactivePooledPiece();
    if (piece == null) {
      piece = pieceFactory.CreatePiece() as GameObject;
      piece.transform.SetParent(piecePool.transform);
      pooledPieces.Add(piece);
    }
    piece.SetActive(true);
  }

  // PRIVATE BEHAVIOUR
  private void InitializePool() {
    for (int i = 0; i < GlobalConstants.InitialPooledPiecesAmount; i++) {
      for (int j = 0; j < GlobalConstants.PieceTypeAmount; j++) {
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
        randomIndex = Random.Range(0, GlobalConstants.PieceTypeAmount);
      } while (pooledPiecesIndexes.Contains(randomIndex));

      if (!pooledPieces[randomIndex].activeInHierarchy)
        return pooledPieces[randomIndex];

      pooledPiecesIndexes.Add(randomIndex); 
    }  

    return null;
  }

}