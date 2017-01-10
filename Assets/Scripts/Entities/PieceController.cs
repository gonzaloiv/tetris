using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceController : MonoBehaviour {

  // MONO BEHAVIOUR
  void Start() {
    StartCoroutine(FallDown());
  }

  void OnEnable() {
    EventManager.StartListening("MoveRight", MoveRight);
    EventManager.StartListening("MoveLeft", MoveLeft);
    EventManager.StartListening("MoveDown", MoveDown);
    EventManager.StartListening("Rotate", Rotate);
  }

  void OnDisable() {
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
    transform.Rotate(0, 0, -90, Space.World);
    if(!IsValidBoardPosition())
      transform.Rotate(0, 0, 90, Space.World);
  }

  // PRIVATE BEHAVIOUR
  private IEnumerator FallDown() {
    while (true) {
      Move(new Vector3(0, -GlobalConstants.PieceMovementsSpeed, 0));
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }
 
  private void Move(Vector3 translation) {
    transform.Translate(translation, Space.World);
      if(!IsValidBoardPosition())
      transform.Translate(-translation, Space.World);
  }

  private bool IsValidBoardPosition() {
    foreach (Transform cube in transform) {
      Vector3 position = cube.position;
      if(!InsideBoard(position))
        return false;
    }
    return true;
  }

  private bool InsideBoard(Vector3 position) {
    if(position.x >= 0 && position.x <= GlobalConstants.BoardWidth - 1 && position.y >= 0)
        return true;
    return false;
  }
   
}