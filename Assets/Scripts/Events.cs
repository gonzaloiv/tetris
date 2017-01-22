using UnityEngine.Events;

// GAME EVENTS
public class RestartGame : UnityEvent {}
public class EndGame : UnityEvent {}

// GAME MECHANICS EVENTS
public class FillBoardWithPiece : UnityEvent {}
public class SpawnPiece : UnityEvent {}

// PLAYER INPUT EVENTS
public class MoveRight : UnityEvent {}
public class MoveLeft : UnityEvent {}
public class MoveDown : UnityEvent {}
public class Rotate : UnityEvent {}
