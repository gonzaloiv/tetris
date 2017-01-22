using UnityEngine;
using System.Collections;

public class Game : StateMachine {

  // MONO BEHAVIOUR
  void Start() {
    ChangeState<PlayGameState>();
  }

  void OnEnable() {
    EventManager.StartListening<EndGame>(ChangeState<EndGameState>);
    EventManager.StartListening<RestartGame>(ChangeState<PlayGameState>);
  }

  void OnDisable() {
    EventManager.StopListening<EndGame>(ChangeState<EndGameState>);
    EventManager.StopListening<RestartGame>(ChangeState<PlayGameState>);
  }

}