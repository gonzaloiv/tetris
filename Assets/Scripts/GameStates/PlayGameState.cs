using UnityEngine;
using System.Collections;

public class PlayGameState : State {

  // PREFABS
  [SerializeField] private GameObject boardPrefab;

  // VARIABLES
  private PieceFactory pieceFactory;

  // MONO BEHAVIOUR
  void Awake() {
    Instantiate(boardPrefab, transform).GetComponent<BoardController>();
    pieceFactory = GetComponent<PieceFactory>();
  }

  public override void Enter() {
    base.Enter();
   
    pieceFactory.CreatePiece();
    StartCoroutine(SimulateGravity());
  }

  public override void Exit() {
    base.Exit();
   
    DisableGamePieces();
  }
 
  protected override void AddListeners() {
    EventManager.StartListening<PieceHitEvent>(NextPiece);
  }

  protected override void RemoveListeners() {
    EventManager.StopListening<PieceHitEvent>(NextPiece);
  }

  // ACTIONS
  void NextPiece(PieceHitEvent pieceHitEvent) {     
    pieceFactory.CreatePiece();
  }
 
  // PRIVATE
  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent(new MoveDownEvent());
      yield return new WaitForSeconds(Config.GravitySpeed);
    }
  }

  private void DisableGamePieces() {
    GameObject pieces = GameObject.Find("GamePieces");
      foreach(GameObject piece in pieces.transform)
        piece.SetActive(false);
  }

}
