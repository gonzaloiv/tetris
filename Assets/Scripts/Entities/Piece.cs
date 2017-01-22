using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Piece : MonoBehaviour {

  // MONO BEHAVIOUR
  void Start() {
    if (IsEmptyPiecePosition() != PositionStates.Empty) {
      EventManager.TriggerEvent(new EndGameEvent());
      gameObject.SetActive(false);
    }
    EnableListeners();
  }

  void EnableListeners() {
    EventManager.StartListening<MoveRightEvent>(OnMoveRight);
    EventManager.StartListening<MoveLeftEvent>(OnMoveLeft);
    EventManager.StartListening<MoveDownEvent>(OnMoveDown);
    EventManager.StartListening<RotateEvent>(OnRotate);
  }

  void DisableListeners() {
    EventManager.StopListening<MoveRightEvent>(OnMoveRight);
    EventManager.StopListening<MoveLeftEvent>(OnMoveLeft);
    EventManager.StopListening<MoveDownEvent>(OnMoveDown);
    EventManager.StopListening<RotateEvent>(OnRotate);
  }

  // ACTIONS
  private void OnMoveRight(MoveRightEvent moveRightEvent) {
    Move(new Vector3(Config.PieceMovementsSpeed, 0, 0));
  }

  private void OnMoveLeft(MoveLeftEvent moveLeftEvent) {
    Move(new Vector3(-Config.PieceMovementsSpeed, 0, 0));
  }

  private void OnMoveDown(MoveDownEvent moveDownEvent) {
    Move(new Vector3(0, -Config.PieceMovementsSpeed, 0));
  }
 
  private void OnRotate(RotateEvent rotateEvent) {
    RotateCubes(-Config.PieceRotationAngle);
    if (IsEmptyPiecePosition() == PositionStates.Out)
      RotateCubes(Config.PieceRotationAngle);
    if (IsEmptyPiecePosition() == PositionStates.Full) {
      RotateCubes(Config.PieceRotationAngle);
      DisablePiece(); 
    }
  }
   
  // PRIVATE BEHAVIOUR
  private void Move(Vector3 translation) {
    transform.Translate(translation, Space.World);
    if (IsEmptyPiecePosition() == PositionStates.Out)
      transform.Translate(-translation, Space.World);
    if (IsEmptyPiecePosition() == PositionStates.Full) {
      transform.Translate(-translation, Space.World);
      DisablePiece();
    } 
  }

  private void RotateCubes(int angle) {
    foreach (Transform cube in transform) {
      cube.RotateAround(transform.position, Vector3.forward, angle);  
    }
  }

  private PositionStates IsEmptyPiecePosition() {
    Vector3 position;
    foreach (Transform cube in transform) {
      position = cube.position;
      if (!IsInsideBoard(position))
        return PositionStates.Out;   
      if (!IsEmptyPosition(position))
        return PositionStates.Full;
    }
    return PositionStates.Empty;
  }

  private bool IsInsideBoard(Vector3 position) {
    return position.x >= 0 && position.x <= Config.BoardWidth - 1;
  }

  private bool IsEmptyPosition(Vector3 position) {  
    return Board.IsPositionEmpty(position) && position.y > 0;
  }

  private void DisablePiece() {
    DisableListeners();
    EventManager.TriggerEvent(new PieceHitEvent(gameObject));
  }
   
}