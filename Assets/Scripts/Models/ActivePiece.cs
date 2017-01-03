using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

  // MONO BEHAVIOUR
  void Awake() {
    Debug.Log(gameObject);
    Debug.Log("Here!");
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
    Vector3 vector3 = new Vector3();
    vector3.x = -GlobalConstants.PieceMovementsSpeed;
    gameObject.transform.Translate(vector3);
  }

  private void MoveRight() {
    Vector3 vector3 = new Vector3();
    vector3.x = GlobalConstants.PieceMovementsSpeed;
    this.transform.Translate(vector3);
  }

  private void MoveDown() {
    this.transform.Translate(Vector3.down  * GlobalConstants.PieceMovementsSpeed * 100 * Time.deltaTime);
  }

  private void Rotate() {
    Vector3 vector3 = new Vector3();
    vector3.x = GlobalConstants.PieceMovementsSpeed;
    this.transform.Rotate(vector3);
  }

}