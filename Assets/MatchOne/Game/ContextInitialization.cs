using Entitas.Generators.Attributes;

namespace MatchOne
{
    public static partial class ContextInitialization
    {
        public static void InitializeContexts()
        {
            InitializeGameContext();
            InitializeGameStateContext();
            InitializeInputContext();
            InitializeConfigContext();
        }

        [ContextInitialization(typeof(GameContext))]
        public static partial void InitializeGameContext();

        [ContextInitialization(typeof(GameStateContext))]
        public static partial void InitializeGameStateContext();

        [ContextInitialization(typeof(InputContext))]
        public static partial void InitializeInputContext();

        [ContextInitialization(typeof(ConfigContext))]
        public static partial void InitializeConfigContext();
    }
}
