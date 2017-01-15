﻿using UnityEngine;
using System.Collections;

public class PlayGameState : GameState {

  // PREFABS
  [SerializeField] private GameObject boardPrefab;

  // VARIABLES
  private Board board;
  private PieceFactory pieceFactory;
  private GameObject activePiece;

  // MONO BEHAVIOUR
  public override void Initialize() {
    board = Instantiate(boardPrefab).GetComponent<Board>();
    pieceFactory = GetComponent<PieceFactory>();
  }

  public override void Enter()  {
    base.Enter();
   
    SpawnPiece();
    StartCoroutine(SimulateGravity());
  }

  public override void Exit() {
    base.Exit();

    DestroyGamePieces();    
    board.ResetGrid();
  }

  protected override void AddListeners() {
    EventManager.StartListening("SpawnPiece", SpawnPiece);
    EventManager.StartListening("FillBoardWithPiece", FillBoardWithPiece);
  }

  protected override void RemoveListeners() {
    EventManager.StopListening("SpawnPiece", SpawnPiece);
    EventManager.StopListening("FillBoardWithPiece", FillBoardWithPiece);
  }

  // ACTIONS
  void SpawnPiece() {
    activePiece = pieceFactory.CreatePiece(); 
  }
  
  void FillBoardWithPiece () {
    board.FillBoardWithPiece(activePiece.transform);
  }

  // PRIVATE
  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent("MoveDown");
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }

  private void DestroyGamePieces() {
    Transform pieces = GameObject.Find("GamePieces").transform;
    foreach(Transform piece in pieces) {
      Destroy(piece);
    }
  }

}