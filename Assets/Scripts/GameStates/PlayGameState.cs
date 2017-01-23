using UnityEngine;
using System.Collections;

public class PlayGameState : State {

  // PREFABS
  [SerializeField] private GameObject boardPrefab;

  // MONO BEHAVIOUR
  void Awake() {
    Instantiate(boardPrefab, transform).GetComponent<BoardController>();
  }

  public override void Enter() {
    base.Enter();
   
    PieceSpawner.Instance.NextPiece();
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
    PieceSpawner.Instance.NextPiece();
  }
 
  // PRIVATE
  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent(new MoveDownEvent());
      yield return new WaitForSeconds(Config.GravitySpeed);
    }
  }

  private void DisableGamePieces() {
    GameObject pieces = GameObject.Find("PiecePool");
      foreach(GameObject piece in pieces.transform)
        piece.SetActive(false);
  }

}
