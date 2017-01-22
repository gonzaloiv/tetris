using UnityEngine;
using System.Collections;

public class EndGameState : State {

  // PREFABS
  [SerializeField] private GameObject restartScreenPrefab;

  // VARIABLES
  private GameObject restartScreen;

  // GAME STATE BEHAVIOUR
  public override void Enter() {
    restartScreen = Instantiate(restartScreenPrefab, transform) as GameObject;
  }

  public override void Exit() {
   base.Exit(); 

   Destroy(restartScreen);
  }

}
