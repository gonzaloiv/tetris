using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  // STATES
  [HideInInspector] public GameState currentState;
  [HideInInspector] public PlayGameState playState;
  [HideInInspector] public EndGameState gameOverState;
 
  // VARIABLES
  private Board board;
  private PieceFactory pieceFactory;
  private GameObject activePiece;
  private GameObject restartScreen;

  // MONO BEHAVIOUR
  void Awake() {
    playState = GetComponent<PlayGameState>();
    playState.Initialize();
    gameOverState = GetComponent<EndGameState>();
  }

  void Start() {
    currentState = playState;
    currentState.Enter();
  }

  void OnEnable() {
    EventManager.StartListening("EndGame", EndGame);
    EventManager.StartListening("RestartGame", RestartGame);
  }

  void OnDisable() {
    EventManager.StopListening("EndGame", EndGame);
    EventManager.StopListening("RestartGame", RestartGame);
  }

  // ACTIONS
  void EndGame() {
    ChangeState(currentState, gameOverState);
  }

  void RestartGame() {
    ChangeState(currentState, playState);
  }

  // PRIVATE BEHAVIOUR
  private void ChangeState(GameState previous, GameState current) {
    previous.Exit();
    current.Enter();
    currentState = current;
  }

}