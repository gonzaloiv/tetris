using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  // PREFABS
  [SerializeField]
  private GameObject boardPrefab;
  [SerializeField]
  private GameObject restartScreenPrefab;

  // VARIABLES
  private Board board;
  private PieceFactory pieceFactory;
  private GameObject activePiece;
  private GameObject restartScreen;

  // MONO BEHAVIOUR
  void Awake() {
    board = Instantiate(boardPrefab).GetComponent<Board>();
    pieceFactory = GetComponent<PieceFactory>();
  }

  void Start() {
    SpawnPiece();
    StartCoroutine(SimulateGravity());
  }

  void OnEnable() {
    EventManager.StartListening("SpawnPiece", SpawnPiece);
    EventManager.StartListening("FillBoardWithPiece", FillBoardWithPiece);
    EventManager.StartListening("EndGame", EndGame);
    EventManager.StartListening("RestartGame", RestartGame);
  }

  void OnDisable() {
    EventManager.StopListening("SpawnPiece", SpawnPiece);
    EventManager.StopListening("FillBoardWithPiece", FillBoardWithPiece);
    EventManager.StopListening("EndGame", EndGame);
    EventManager.StopListening("RestartGame", RestartGame);
  }

  // ACTIONS
  void SpawnPiece() {
    activePiece = pieceFactory.CreatePiece(); 
  }
  
  void FillBoardWithPiece () {
    board.FillBoardWithPiece(activePiece.transform);
  }

  void EndGame() {
    StopCoroutine(SimulateGravity());
    restartScreen = Instantiate(restartScreenPrefab) as GameObject;
  }

  void RestartGame() {
    DestroyGamePieces();    
    Destroy(restartScreen);
    board.ResetGrid();
    SpawnPiece();
  }

  // PRIVATE BEHAVIOUR
  private void DestroyGamePieces() {
    GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gameObject in allObjects) {
      if(gameObject.activeInHierarchy && gameObject.name.Contains("Piece"))
        Destroy(gameObject);
    }
  }

  private IEnumerator SimulateGravity() {
    while (true) {
      EventManager.TriggerEvent("MoveDown");
      yield return new WaitForSeconds(GlobalConstants.GravitySpeed);
    }
  }

}