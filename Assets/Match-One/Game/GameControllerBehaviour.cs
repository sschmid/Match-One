using DG.Tweening;
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
    public ScriptableGameConfig GameConfig;
    public ScriptablePieceColorsConfig PieceColorsConfig;

    GameController _gameController;

    void Awake()
    {
        DOTween.SetTweensCapacity(500, 50);
        _gameController = new GameController(Contexts.sharedInstance, GameConfig, PieceColorsConfig);
    }

    void Start() => _gameController.Initialize();
    void Update() => _gameController.Execute();
}
