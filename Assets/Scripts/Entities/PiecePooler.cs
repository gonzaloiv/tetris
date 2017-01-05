using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePooler : MonoBehaviour {
  
  // VARIABLES
  private List<GameObject> pooledPieces = new List<GameObject> ();
  private PieceFactory pieceFactory;
  private GameObject piece;

  // MONO BEHAVIOUR
  public void Awake() {
    pieceFactory = new PieceFactory();
    for (int i = 0; i < GlobalConstants.InitialPooledPiecesAmount; i++) {
      // TODO: Que no se creen de manera aleatoria sino mediante algún algoritmo que haga unas pieces más regulares que otras
      piece = Instantiate(pieceFactory.CreatePiece(i)) as GameObject;
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
    piece = Instantiate(pieceFactory.CreatePiece()) as GameObject;
    pooledPieces.Add(piece);  
    return piece;
  } 

}