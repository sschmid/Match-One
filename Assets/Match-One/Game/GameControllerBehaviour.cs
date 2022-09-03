using UnityEngine;

/**
 *
 * GameControllerBehaviour is the entry point to Match One
 *
 * The only purpose of this class is to redirect and forward
 * the Unity lifecycle events to the GameController
 *
 */

public class GameControllerBehaviour : MonoBehaviour
{
    public ScriptableGameConfig gameConfig;

    GameController _gameController;

    void Awake() => _gameController = new GameController(Contexts.sharedInstance, gameConfig);
    void Start() => _gameController.Initialize();
    void Update() => _gameController.Execute();
}
