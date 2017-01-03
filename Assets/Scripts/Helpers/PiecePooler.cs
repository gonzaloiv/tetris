using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePooler : MonoBehaviour {
  
  // VARIABLES
  public GameObject[] piecesPrefabs;

  private List<GameObject> pooledPieces = new List<GameObject> ();
  private GameObject piece;

  // PROPERTIES
  public static int RandomPrefabIndex {
    get { return Random.Range(0, GlobalConstants.PieceTypeAmount); }
  }
 
  // MONO BEHAVIOUR
  public void Awake() {
    for (int i = 0; i < GlobalConstants.InitialPooledPiecesAmount; i++) {
      // TODO: Que no se creen de manera aleatoria sino mediante algún algoritmo que haga unas pieces más regulares que otras
      piece = Instantiate(piecesPrefabs[RandomPrefabIndex]) as GameObject;
      piece.SetActive(false);
      pooledPieces.Add(piece);
    }
  }

  // PUBLIC BEHAVIOUR
  public GameObject GetPiece() {
    for (int i = 0; i < pooledPieces.Count; i++) {
      if (!pooledPieces[i].activeInHierarchy) 
        return pooledPieces[i];
    }  
    piece = Instantiate(piecesPrefabs[RandomPrefabIndex]) as GameObject;
    pooledPieces.Add(piece);  
    return piece;
  }

}