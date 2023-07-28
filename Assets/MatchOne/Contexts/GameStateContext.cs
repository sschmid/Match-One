using Entitas;

namespace MatchOne
{
    partial class GameStateContext : IContext
    {
        public static GameStateContext Instance
        {
            get => _instance ??= new GameStateContext();
            set => _instance = value;
        }

        static GameStateContext _instance;
    }
}
