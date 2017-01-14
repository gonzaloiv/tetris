using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Piece : MonoBehaviour {

  // MONO BEHAVIOUR
  void Start() {
    if (IsEmptyBoardPosition() != PositionStates.Empty) {
      EventManager.TriggerEvent("EndGame");
      Destroy(gameObject);
    }
    EnableListeners();
  }

  void EnableListeners() {
    EventManager.StartListening("MoveRight", MoveRight);
    EventManager.StartListening("MoveLeft", MoveLeft);
    EventManager.StartListening("MoveDown", MoveDown);
    EventManager.StartListening("Rotate", Rotate);
  }

  void DisableListeners() {
    EventManager.StopListening("MoveRight", MoveRight);
    EventManager.StopListening("MoveLeft", MoveLeft);
    EventManager.StopListening("MoveDown", MoveDown);
    EventManager.StopListening("Rotate", Rotate);
  }

  // ACTIONS
  private void MoveLeft() {
    Move(new Vector3(-GlobalConstants.PieceMovementsSpeed, 0, 0));
  }

  private void MoveRight() {
    Move(new Vector3(GlobalConstants.PieceMovementsSpeed, 0, 0));
  }

  private void MoveDown() {
    Move(new Vector3(0, -GlobalConstants.PieceMovementsSpeed, 0));
  }
 
  private void Rotate() {
    Vector3 rotation = new Vector3(0, 0, -90);
    transform.Rotate(rotation);
    if(IsEmptyBoardPosition() != 0)
      transform.Rotate(-rotation);
  }
   
  // PRIVATE BEHAVIOUR
  private void Move(Vector3 translation) {
    transform.Translate(translation, Space.World);
    if (IsEmptyBoardPosition() == PositionStates.Out)
      transform.Translate(-translation, Space.World);
    if (IsEmptyBoardPosition() == PositionStates.Full) {
      transform.Translate(-translation, Space.World);
      DisableListeners();
      Board.FillBoardWithPiece(gameObject.transform);
      EventManager.TriggerEvent("SpawnPiece");
    } 
  }

  private PositionStates IsEmptyBoardPosition() {
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
    return position.x >= 0 && position.x <= GlobalConstants.BoardWidth - 1;
  }

  private bool IsEmptyPosition(Vector3 position) {  
    return Board.IsPositionEmpty(position) && position.y > 0;
  }
   
}