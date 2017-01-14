using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

  void Update() {
    // DESKTOP CONTROLLER
    if (Input.GetKeyDown("space")) {
      Debug.Log("Space pressed!"); 
      EventManager.TriggerEvent("Rotate");
    }

    if (Input.GetKeyDown("down")) {
      Debug.Log("DownArrow pressed!"); 
      EventManager.TriggerEvent("MoveDown");
    }

    if (Input.GetKeyDown("left")) {
      EventManager.TriggerEvent("MoveLeft");
    }

    if (Input.GetKeyDown("right")) {
      Debug.Log("RightArrow pressed!"); 
      EventManager.TriggerEvent("MoveRight");
    }

    if (Input.GetKeyDown("return")) {
      Debug.Log("Enter pressed!"); 
      EventManager.TriggerEvent("RestartGame");
    }
  }

}