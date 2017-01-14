using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Piece : MonoBehaviour {

  // MONO BEHAVIOUR
  void Start() {
    if (IsEmptyBoardPosition() != 0) {
      EventManager.TriggerEvent("EndGame");
      Destroy(gameObject);
    }
  }

  void OnEnable() {
    EventManager.StartListening("MoveRight", MoveRight);
    EventManager.StartListening("MoveLeft", MoveLeft);
    EventManager.StartListening("MoveDown", MoveDown);
    EventManager.StartListening("Rotate", Rotate);
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
 
  // TODO: mejorar la rotación de las piezas
  private void Rotate() {
    Vector3 rotation = new Vector3(0, 0, -90);
    transform.Rotate(rotation);
    if(IsEmptyBoardPosition() != 0)
      transform.Rotate(-rotation);
  }

  // PRIVATE BEHAVIOUR
  private void Move(Vector3 translation) {
    transform.Translate(translation, Space.World);
    if (IsEmptyBoardPosition() == 1)
      transform.Translate(-translation, Space.World);
    if (IsEmptyBoardPosition() == 2) {
      transform.Translate(-translation, Space.World);
      DisableListeners();
      EventManager.TriggerEvent("FillBoardWithPiece");
      EventManager.TriggerEvent("SpawnPiece");
    } 
  }

  // TODO: refactorizar esto para que no sea un truño (al menos meterlo como global constants)
  private int IsEmptyBoardPosition() {
    Vector3 position;
    foreach (Transform cube in transform) {
      position = cube.position;
      if (!IsInsideBoard(position))
        return 1;   
      if (!IsEmptyPosition(position))
        return 2;
    }
    return 0;
  }

  private bool IsInsideBoard(Vector3 position) {
    return position.x >= 0 && position.x <= GlobalConstants.BoardWidth - 1;
  }

  private bool IsEmptyPosition(Vector3 position) {  
    return Board.IsPositionEmpty(position) && position.y > 0;
  }
   
  private void DisableListeners() {
    EventManager.StopListening("MoveRight", MoveRight);
    EventManager.StopListening("MoveLeft", MoveLeft);
    EventManager.StopListening("MoveDown", MoveDown);
    EventManager.StopListening("Rotate", Rotate);
  }

}