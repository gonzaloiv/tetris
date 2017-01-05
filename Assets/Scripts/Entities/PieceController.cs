using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceController : MonoBehaviour {

  // MONO BEHAVIOUR
  void Awake() {
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
    transform.Translate(new Vector3(-GlobalConstants.PieceMovementsSpeed, 0, 0));
    if(!IsValidBoardPosition())
     transform.Translate(new Vector3(GlobalConstants.PieceMovementsSpeed, 0, 0));
  }

  private void MoveRight() {
    transform.Translate(new Vector3(GlobalConstants.PieceMovementsSpeed, 0, 0));
    if(!IsValidBoardPosition())
      transform.Translate(new Vector3(-GlobalConstants.PieceMovementsSpeed, 0, 0));
  }

  private void MoveDown() {
    transform.Translate(new Vector3(0, -GlobalConstants.PieceMovementsSpeed, 0));
    if(!IsValidBoardPosition())
      transform.Translate(new Vector3(0, GlobalConstants.PieceMovementsSpeed, 0));
  }

  private void Rotate() {
    transform.Rotate(0, 0, -90);
    if(!IsValidBoardPosition())
      transform.Rotate(0, 0, 90);
  }

  // PRIVATE BEHAVIOUR
  private IEnumerator FallDown() {
    while (true) {
      MoveDown();
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }

  private bool IsValidBoardPosition() {
    foreach (Transform cube in transform) {
      Debug.Log(cube.position);
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