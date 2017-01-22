using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

  #region MonoBehaviour

  void Update() {
    if (Input.GetKeyDown("space"))
      EventManager.TriggerEvent(new RotateEvent());

    if (Input.GetKeyDown("down"))
      EventManager.TriggerEvent(new MoveDownEvent());

    if (Input.GetKeyDown("left"))
      EventManager.TriggerEvent(new MoveLeftEvent());

    if (Input.GetKeyDown("right"))
      EventManager.TriggerEvent(new MoveRightEvent());

    if (Input.GetKeyDown("return"))
      EventManager.TriggerEvent(new RestartGameEvent());
  }

  #endregion

}