using UnityEngine;

namespace MatchOne
{
    /**
     *
     * GameControllerBehaviour is the entry point to MatchOne
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

        void Awake() => _gameController = new GameController(GameConfig, PieceColorsConfig);
        void Start() => _gameController.Initialize();
        void Update() => _gameController.Execute();
    }
}
