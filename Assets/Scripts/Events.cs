using UnityEngine;
using UnityEngine.Events;

// GAME EVENTS
public class RestartGameEvent : UnityEvent {}
public class EndGameEvent : UnityEvent {}

// GAME MECHANICS EVENTS
public class PieceHitEvent : UnityEvent {
  public GameObject piece;
  public PieceHitEvent(GameObject piece) {
    this.piece = piece;
  }
}

// PLAYER INPUT EVENTS
public class MoveRightEvent : UnityEvent {}
public class MoveLeftEvent : UnityEvent {}
public class MoveDownEvent : UnityEvent {}
public class RotateEvent : UnityEvent {}