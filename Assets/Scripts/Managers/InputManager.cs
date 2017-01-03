using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

  // EVENTS
  void Update() {
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
  }

  // TODO: mobile controls

}