using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

  void Update() {

    // DESKTOP CONTROLLER
    if (Input.GetKeyDown("space")) {
      Debug.Log("Space pressed!"); 
      EventManager.TriggerEvent(new Rotate());
    }

    if (Input.GetKeyDown("down")) {
      Debug.Log("DownArrow pressed!"); 
      EventManager.TriggerEvent(new MoveDown());
    }

    if (Input.GetKeyDown("left")) {
      EventManager.TriggerEvent(new MoveLeft());
    }

    if (Input.GetKeyDown("right")) {
      Debug.Log("RightArrow pressed!"); 
      EventManager.TriggerEvent(new MoveRight());
    }

    if (Input.GetKeyDown("return")) {
      Debug.Log("Enter pressed!"); 
      EventManager.TriggerEvent(new RestartGame());
    }
  }

}