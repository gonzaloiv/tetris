using UnityEngine;
using System.Collections;

public class Game : StateMachine {

  // MONO BEHAVIOUR
  void Start() {
    ChangeState<PlayGameState>();
  }

  void OnEnable() {
    EventManager.StartListening<EndGameEvent>(OnEndGameEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<EndGameEvent>(OnEndGameEvent);
    EventManager.StopListening<RestartGameEvent>(OnRestartGameEvent);
  }

  // ACTIONS
  private void OnEndGameEvent(EndGameEvent endGameEvent) {
    ChangeState<EndGameState>();
  }

  private void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    ChangeState<PlayGameState>();
  }

}