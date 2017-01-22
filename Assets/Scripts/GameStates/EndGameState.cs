using UnityEngine;
using System.Collections;

public class EndGameState : State {

  // PREFABS
  [SerializeField] private GameObject restartScreenPrefab;

  // VARIABLES
  private GameObject restartScreen;

  // GAME STATE BEHAVIOUR
  public override void Enter() {
    if (!restartScreen)
      restartScreen = Instantiate(restartScreenPrefab, transform) as GameObject;

    restartScreen.SetActive(true);
  }

  public override void Exit() {
    base.Exit(); 

    restartScreen.SetActive(false);
  }

}
