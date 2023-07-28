using System;
using DG.Tweening;
using Entitas;
using Entitas.Unity;

namespace MatchOne
{
    /**
     *
     * The GameController creates and manages all systems in MatchOne
     *
     */
    public class GameController
    {
        readonly Systems _systems;

        public GameController(IGameConfig gameConfig, IPieceColorsConfig pieceColorsConfig)
        {
            DOTween.SetTweensCapacity(1000, 50);

            var random = new Random(DateTime.UtcNow.Millisecond);
            UnityEngine.Random.InitState(random.Next());
            Rand.Game = new Rand(random.Next());

            ContextInitialization.InitializeContexts();
            var gameContext = GameContext.Instance.AddCustomEntityIndexes();
            var gameStateContext = GameStateContext.Instance;
            var inputContext = InputContext.Instance;
            var configContext = ConfigContext.Instance;

            gameContext.CreateContextObserver();
            gameStateContext.CreateContextObserver();
            inputContext.CreateContextObserver();
            configContext.CreateContextObserver();

            configContext.SetGameConfig(gameConfig);
            configContext.SetPieceColorsConfig(pieceColorsConfig);

            // This is the heart of MatchOne:
            // All logic is contained in all the sub systems of GameSystems
            _systems = new GameSystems(
                gameContext,
                gameStateContext,
                inputContext,
                configContext
            );
        }

        public void Initialize()
        {
            // This calls Initialize() on all sub systems
            _systems.Initialize();
        }

        public void Execute()
        {
            // This calls Execute() and Cleanup() on all sub systems
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
