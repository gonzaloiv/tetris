using UnityEngine;
using System.Collections;

public abstract class GameState : MonoBehaviour {

  // PUBLIC BEHAVIOUR
  public virtual void Initialize() {}

  public virtual void Enter() {
    AddListeners();
  }
  public virtual void Exit() {
    RemoveListeners();
  }

  // PROTECTED BEHAVIOUR
  protected virtual void AddListeners() {}
  protected virtual void RemoveListeners() {}

}
